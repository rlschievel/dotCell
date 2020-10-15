using dotCell.ViewModels;
using dotCell.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace dotCell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                MainWindowView mainWindow = new MainWindowView();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }            
        }
    }
}
