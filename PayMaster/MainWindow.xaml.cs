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

            //sqlPerson.AddPerson(new Person("Tomek", "Domek", false));
            sqlPerson.GetAllPersons();


            // sqlTransaction.AddTransaction(new Transaction("2020-12-22", 3, -50, false));
            sqlTransaction.GetTransactionByPayment(false);

            
        }
    }
}
