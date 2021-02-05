using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SQLPerson sqlPerson = new SQLPerson();
        SQLTransaction sqlTransaction = new SQLTransaction();
        SQLPayTarget sqlPayTarget = new SQLPayTarget();

        public MainWindow()
        {
            
            InitializeComponent();

            sqlPerson.CreateTablePersons();
            sqlTransaction.CreateTableTransactions();
            sqlPayTarget.CreateTablePayTarget();
            //MessageBox.Show(i.ToString());
            
            MainGrid.ItemsSource = sqlTransaction.GetAllTransactionList();

            DataContext = new AccountBalance();
        }

       
        private void BtnPayIn_Click(object sender, RoutedEventArgs e)
        {
            PayIn payIn = new PayIn();
            this.Close();
            payIn.Show();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            Payers payers = new Payers();
            this.Close();
            payers.Show();
        }

        private void BtnPayOut_Click(object sender, RoutedEventArgs e)
        {
            PayOut payOut = new PayOut();
            this.Close();
            payOut.Show();
        }

        private void BtnTargets_Click(object sender, RoutedEventArgs e)
        {
            Targets targets = new Targets();
            this.Close();
            targets.Show();
        }
    }
}
