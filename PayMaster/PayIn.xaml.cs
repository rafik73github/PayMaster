using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using PayMaster.SQL;
using PayMaster.Tools;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy PayIn.xaml
    /// </summary>
    public partial class PayIn : Window
    {

        private readonly SQLPerson sqlPerson = new SQLPerson();
        private readonly SQLTransaction sqlTransaction = new SQLTransaction();
        private readonly SQLPayTarget sqlPayTarget = new SQLPayTarget();
        List<PersonModel> person = new SQLPerson().GetAllPersons();
        public PayIn()
        {
            InitializeComponent();

           // List<Person> person = sqlPerson.GetAllPersons();
            ComboBoxAddTransactionPayer.ItemsSource = person;
            ComboBoxAddTransactionPayer.SelectedValuePath = "PersonId";

            List<PayTargetModel> target = sqlPayTarget.GetAllPayTargets();
            ComboBoxAddTransactionTarget.ItemsSource = target;

            TxtAddTransactionAmount.PreviewKeyDown += ValidateText.NoSpaceTextbox;
            TxtAddTransactionAmount.PreviewTextInput += ValidateText.NumberValidatinTextBox;

            PayInDatePicker.DisplayDate = DateTime.Now.Date;

        }

        

        private void ComboBoxAddTransactionPayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Person person = ComboBoxAddTransactionPayer.SelectedItem as Person;
            //string test = person.PersonId.ToString();
            
           // MessageBox.Show(test);
        }

        private void PayInBtnOk_Click(object sender, RoutedEventArgs e)
        {
            double transactionAmount;
            if (!PayInDatePicker.Text.Equals("") 
                && ComboBoxAddTransactionPayer.SelectedItem != null
                && ComboBoxAddTransactionTarget.SelectedItem != null
                && !TxtAddTransactionAmount.Text.Trim().Equals(""))
            {
                string transactionDate = Convert.ToDateTime(PayInDatePicker.Text.Trim()).ToString("yyyy-MM-dd");
                PersonModel person = ComboBoxAddTransactionPayer.SelectedItem as PersonModel;
                int transactionPersonId = person.PersonId;
                string transactionAmountTxt = TxtAddTransactionAmount.Text;
                PayTargetModel payTarget = ComboBoxAddTransactionTarget.SelectedItem as PayTargetModel;
                int transactionTarget = payTarget.PayTargetId;
                string transactionDescription = TxtAddTransactionDescription.Text.Trim().ToUpper();
                bool transactionPayIn = true;

                Regex regex = new Regex(@"^[0-9]{1,5}\,?([0-9]{1,2})?$");
                transactionAmount = Convert.ToDouble(transactionAmountTxt);
                if (!regex.IsMatch(transactionAmountTxt))
                {
                    MessageBox.Show("NIEPOPRAWNY FORMAT W POLU 'KWOTA'");
                }
                else if(transactionAmount == 0)
                {
                    MessageBox.Show("WPROWADŹ KWOTĘ WIĘKSZĄ OD ZERA !");
                }
                else
                {
                    
                    sqlTransaction.AddTransaction(new TransactionModel(
                        transactionDate,
                        transactionPersonId,
                        transactionAmount,
                        transactionDescription,
                        transactionTarget,
                        transactionPayIn
                        ));

                    PayInDatePicker.Text = "";
                    ComboBoxAddTransactionPayer.SelectedItem = null;
                    ComboBoxAddTransactionTarget.SelectedItem = null;
                    TxtAddTransactionAmount.Text = "";
                    TxtAddTransactionDescription.Text = "";
                    MessageBox.Show("ZAKSIĘGOWANO WPŁATĘ: " + transactionAmount.ToString() + " ZŁ");
                }
                

            }
            else
            {
                MessageBox.Show("WYPEŁNIJ WSZYSTKIE POLA!\nPOLE 'OPIS' NIE JEST OBOWIĄZKOWE");
            }
            
            
        }

        private void PayInBtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
/*
        string _prevText = string.Empty;

        private void ComboBoxAddTransactionPayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach(var item in ComboBoxAddTransactionPayer.Items)
            {
                if (item.ToString().StartsWith(ComboBoxAddTransactionPayer.Text))
                {
                    _prevText = ComboBoxAddTransactionPayer.Text;
                    return;
                }
            }
            ComboBoxAddTransactionPayer.Text = _prevText;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var cmbx = sender as ComboBox;
            cmbx.ItemsSource = from item in person
                               where item.PersonName.ToLower().Contains(cmbx.Text.ToLower())
                               select item;
            if (cmbx.ItemsSource != null)
            {
                cmbx.IsDropDownOpen = true;
            }
            else
            {
                cmbx.IsDropDownOpen = false;
            }
        }
*/




    }
}
