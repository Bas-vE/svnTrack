using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using svnTrack.Views;

namespace svnTrack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Because we removed the loading of the startup uri from the xaml file
            //we need to set our mainwindow by code and show the mainwindow
            this.MainWindow = new MainWindow();
            this.MainWindow.Show();
        }
    }
}
