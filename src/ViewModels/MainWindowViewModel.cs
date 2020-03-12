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

namespace svnTrack.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        #region Private Commands

        private ICommand _exampleCommand;

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
        }


        #region Public Properties

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
        #endregion Public Properties

        #region Public Commands

        /// <summary>
        /// This is the command the buttoncommand binds on
        /// </summary>
        public ICommand ExampleCommand
        {
            get
            {
                if (_exampleCommand == null)
                {
                    _exampleCommand = new RelayCommand(
                        param => Example_Execute(),
                        param => Example_CanExecute()
                    );
                }
                return _exampleCommand;
            }
        }

        /// <summary>
        /// This method is called with the command is executed
        /// </summary>
        private void Example_Execute()
        {
            //publish on the exampleMessage
            MessageHub.Instance.Publish(new ExampleMessage($"Random Number: {new Random(DateTime.Now.Millisecond).Next()}"));

        }

        /// <summary>
        /// This method is called when properties change and controls the enable state of the command
        /// </summary>
        /// <returns>true if the button is enabled, false if the button is disabled</returns>
        private bool Example_CanExecute()
        {
            return true;

        }

        #endregion Public Commands
    }
}
