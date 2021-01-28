﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy PayIn.xaml
    /// </summary>
    public partial class PayIn : Window
    {
        private readonly SQLPerson sqlPerson = new SQLPerson();
        private readonly SQLTransaction sqlTransaction = new SQLTransaction();
        public PayIn()
        {
            InitializeComponent();

            List<Person> person = sqlPerson.GetAllPersons();
            ComboBoxAddTransactionPayer.ItemsSource = person;
            ComboBoxAddTransactionPayer.SelectedValuePath = "PersonId";

            
            
        }

        

        private void ComboBoxAddTransactionPayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = ComboBoxAddTransactionPayer.SelectedItem as Person;
            string test = person.PersonId.ToString();
           // MessageBox.Show(test);
        }

        private void PayInBtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!PayInDatePicker.Text.Equals("") && ComboBoxAddTransactionPayer.SelectedItem != null && !TxtAddTransactionAmount.Text.Trim().Equals(""))
            {
                string transactionDate = Convert.ToDateTime(PayInDatePicker.Text.Trim()).ToString("yyyy-MM-dd");
                Person person = ComboBoxAddTransactionPayer.SelectedItem as Person;
                int transactionPersonId = person.PersonId;
                string transactionAmount = TxtAddTransactionAmount.Text.Trim();
                string transactionDescription = TxtAddTransactionDescription.Text.Trim().ToUpper();
                bool transactionPayIn = true;

                sqlTransaction.AddTransaction(new Transaction(transactionDate, transactionPersonId, transactionAmount, transactionDescription, transactionPayIn));

                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
                // MessageBox.Show(transactionAmount);
            }
        }

        private void PayInBtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void NumberValidatinTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}