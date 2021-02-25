using System.Windows;
using PayMaster.SQL;

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
            new SQLTransaction().CreateTableTransactions();
            new SQLPayTarget().CreateTablePayTarget();

            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }



    }
}
