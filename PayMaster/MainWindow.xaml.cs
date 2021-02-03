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
        public MainWindow()
        {
            InitializeComponent();

            sqlPerson.CreateTablePersons();
            sqlTransaction.CreateTableTransactions();

            int x = 1022;


            double y = (Convert.ToDouble(x))/100;
            int z = Convert.ToInt32(y*100);

            string str = "10";

            
            int i = Convert.ToInt32((Convert.ToDouble(str)) * 100);
            //MessageBox.Show(i.ToString());

            //sqlPerson.AddPerson(new Person("Mirek", "Świrek", false));
            // sqlPerson.GetAllPersons();


            //sqlTransaction.AddTransaction(new Transaction("2020-11-01", 3, "650","wypłata", false));

            // sqlTransaction.GetTransactionByPayment(false);

            MainGrid.ItemsSource = sqlTransaction.GetAllTransactionList();
            
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
    }
}
