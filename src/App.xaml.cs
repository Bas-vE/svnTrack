using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using svnTrack.Models;
using svnTrack.Views;

namespace svnTrack
{
    public enum Skin
    {
        Dark,
        Light
    }
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Skin Skin { get; set; } = Skin.Dark;

        public void ChangeSkin(Skin newSkin)
        {
            Skin = newSkin;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Clear();

            if (Skin == Skin.Dark)
                ApplyResources("Resources/Dark.xaml");
            else if (Skin == Skin.Light)
                ApplyResources("Resources/Light.xaml");
        }

        private void ApplyResources(string src)
        {
            var dict = new ResourceDictionary() { Source = new Uri(src, UriKind.Relative) };
            foreach (var mergeDict in dict.MergedDictionaries)
            {
                Application.Current.Resources.MergedDictionaries.Add(mergeDict);
            }

            foreach (var key in dict.Keys)
            {
                Resources[key] = dict[key];
            }
        }

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
