using System;
using System.Collections.Generic;
using System.Globalization;
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
using PayMaster.TimeTools;

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
            //MessageBox.Show(new TimeCalculations().FirstDayOfCurrentYear());

            MainGrid.ItemsSource = sqlTransaction.GetAllTransactionList();

            ComboBoxDefinedDateFilterSelect.ItemsSource = DeclaredDateFilterList();
            ComboBoxDefinedDateFilterSelect.SelectedIndex = 0;

            DateFilterFirst.DisplayDateEnd = DateTime.Now;

            DateFilterLast.DisplayDateEnd = DateTime.Now;

            DataContext = new AccountBalance();

        }

        private List<DefinedDateFilterModel> DeclaredDateFilterList()
        {
            List<DefinedDateFilterModel> result = new List<DefinedDateFilterModel>
            {
                new DefinedDateFilterModel(0, "BIEŻĄCY ROK", new TimeCalculations().FirstDayOfCurrentYear(), DateTime.Now.Date.ToString("yyyy-MM-dd")),
                new DefinedDateFilterModel(1, "WSZYSTKO", DateTime.Now.Date.ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")),
                new DefinedDateFilterModel(2, "OSTATNI MIESIĄC", new TimeCalculations().FirstDayOfMonth(1), new TimeCalculations().LastDayOfLastOfMonth()),
                new DefinedDateFilterModel(3, "OSTATNIE 3 MIESIĄCE", new TimeCalculations().FirstDayOfMonth(3), new TimeCalculations().LastDayOfLastOfMonth()),
                new DefinedDateFilterModel(4, "OSTATNIE 6 MIESIĘCY", new TimeCalculations().FirstDayOfMonth(6), new TimeCalculations().LastDayOfLastOfMonth()),
                new DefinedDateFilterModel(5, "OSTATNIE 12 MIESIĘCY", new TimeCalculations().FirstDayOfMonth(12), new TimeCalculations().LastDayOfLastOfMonth())
            };

            return result;
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
