using System.Windows;
using PayMaster.SQL;
using PayMaster.Models;
using System;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new SQLPerson().CreateTablePersons();
            new SQLPayTarget().CreateTablePayTarget();
            new SQLTransaction().CreateTableTransactions();

            FilterModel.DateIndex = 0;
            FilterModel.FirstDate = "";
            FilterModel.LastDate = "";
            FilterModel.TransactionIndex = 0;
            FilterModel.TargetIndex = 0;
            
            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }



    }
}
