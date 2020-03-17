using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using svnTrack.Core;
using svnTrack.Core.Logging;
using svnTrack.Models.Preferences;
using svnTrack.Core.Messaging;
using svnTrack.Models.Messages;
using svnTrack.Models;
using System.Collections.ObjectModel;
using svnTrack.Models.Svn;
using svnTrack.Views;

namespace svnTrack.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        #region Private Commands

        private ICommand _checkoutCommand;
        private ICommand _updateCommand;
        private ICommand _commandCommand;
        private ICommand _revertCommand;
        private ICommand _getLockCommand;
        private ICommand _releaseLockCommand;
        private ICommand _switchThemeCommand;


        private bool _isdarkTheme = false;

        #endregion Private Commands

        private string _statusBarText = string.Empty;

        public MainWindowViewModel()
        {
            //Get the test values from the userpreferences
            var userBool = UserPreferences.TestBool;

            //Write to the logger that the application was started
            LoggerFactory.GetLogger().WriteMessage("Application", LogLevel.INFO, "Application has been started by the user");

            //subscribe to the ExampleMessage and change the StatusBarText property everytime the a new message gets published
            MessageHub.Instance.Subscribe<ExampleMessage>(m => StatusBarText = m.Message);

            var rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                Repositories.Add(new SvnRepository($"Repository {i.ToString()}",rnd.Next(0, 200)));
            }
        }


        #region Public Properties

        public ObservableCollection<SvnRepository> Repositories { get; } = new ObservableCollection<SvnRepository>();

        public string StatusBarText
        {
            get { return _statusBarText; }
            set
            {
                if (value != _statusBarText)
                {
                    _statusBarText = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsDarkTheme
        {
            get { return _isdarkTheme; }
            set
            {
                if(value != _isdarkTheme)
                {
                    _isdarkTheme = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion Public Properties

        #region Public Commands

        /// <summary>
        /// This is the command the Checkout button binds to
        /// </summary>
        public ICommand CheckoutCommand
        {
            get
            {
                if (_checkoutCommand == null)
                {
                    _checkoutCommand = new RelayCommand(
                        param => Checkout_Execute(),
                        param => Checkout_CanExecute()
                    );
                }
                return _checkoutCommand;
            }
        }

        private void Checkout_Execute()
        {
            new SvnCheckoutView().ShowDialog();
        }

        private bool Checkout_CanExecute()
        {
            return true;

        }

        /// <summary>
        /// This is the command the SwitchTheme button binds to
        /// </summary>
        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand(
                        param => SwitchTheme_Execute(),
                        param => SwitchTheme_CanExecute()
                    );
                }
                return _switchThemeCommand;
            }
        }

        /// <summary>
        /// This method is called with the command is executed
        /// </summary>
        private void SwitchTheme_Execute()
        {
            if(App.Skin == Skin.Dark)
                (App.Current as App).ChangeSkin(Skin.Light);
            else
                (App.Current as App).ChangeSkin(Skin.Dark);

            //publish on the Switch Theme Message
            MessageHub.Instance.Publish(new ExampleMessage($"Theme Switched to {App.Skin.ToString()}"));

        }

        /// <summary>
        /// This method is called when properties change and controls the enable state of the command
        /// </summary>
        /// <returns>true if the button is enabled, false if the button is disabled</returns>
        private bool SwitchTheme_CanExecute()
        {
            return true;

        }

        #endregion Public Commands
    }
}
