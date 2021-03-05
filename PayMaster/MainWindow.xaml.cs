using System;
using System.Collections.Generic;
using System.Windows;
using PayMaster.TimeTools;
using PayMaster.SQL;
using PayMaster.Tools;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        SQLTransaction sqlTransaction = new SQLTransaction();
        
        public MainWindow()
        {
            
            InitializeComponent();

            
            //MessageBox.Show(new TimeCalculations().FirstDayOfCurrentYear());

            MainGrid.ItemsSource = sqlTransaction.GetAllTransactionList();

            ComboBoxDateFilterSelect.ItemsSource = DeclaredDateFilterList();
            ComboBoxDateFilterSelect.SelectedIndex = 0;

            ComboBoxNickFilterSelect.ItemsSource = new SQLPerson().GetPersonsNick();
            ComboBoxNickFilterSelect.SelectedIndex = 0;

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
