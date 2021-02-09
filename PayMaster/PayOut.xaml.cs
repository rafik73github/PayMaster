using System;
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
    /// Logika interakcji dla klasy PayOut.xaml
    /// </summary>
    public partial class PayOut : Window
    {
        private readonly SQLPerson sqlPerson = new SQLPerson();
        private readonly SQLTransaction sqlTransaction = new SQLTransaction();
        private readonly SQLPayTarget sqlPayTarget = new SQLPayTarget();
        public PayOut()
        {
            InitializeComponent();

            List<Person> person = sqlPerson.GetAllPersons();
            ComboBoxAddTransactionPayer.ItemsSource = person;
            ComboBoxAddTransactionPayer.SelectedValuePath = "PersonId";

            List<PayTarget> target = sqlPayTarget.GetAllPayTargets();
            ComboBoxAddTransactionTarget.ItemsSource = target;

            TxtAddTransactionAmount.PreviewKeyDown += Tools.NoSpaceTextbox;
            TxtAddTransactionAmount.PreviewTextInput += Tools.NumberValidatinTextBox;

            PayOutDatePicker.DisplayDate = DateTime.Now.Date;

            

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
            if (!PayOutDatePicker.Text.Equals("")
                 && ComboBoxAddTransactionPayer.SelectedItem != null
                 && ComboBoxAddTransactionTarget.SelectedItem != null
                 && !TxtAddTransactionAmount.Text.Trim().Equals(""))
            {
                string transactionDate = Convert.ToDateTime(PayOutDatePicker.Text.Trim()).ToString("yyyy-MM-dd");
                Person person = ComboBoxAddTransactionPayer.SelectedItem as Person;
                int transactionPersonId = person.PersonId;
                string transactionAmountTxt = TxtAddTransactionAmount.Text;
                PayTarget payTarget = ComboBoxAddTransactionTarget.SelectedItem as PayTarget;
                int transactionTarget = payTarget.PayTargetId;
                string transactionDescription = TxtAddTransactionDescription.Text.Trim().ToUpper();
                bool transactionPayIn = false;

                Regex regex = new Regex(@"^[0-9]{1,5}\,?([0-9]{1,2})?$");

                if (!regex.IsMatch(transactionAmountTxt))
                {
                    MessageBox.Show("NIEPOPRAWNY FORMAT W POLU 'KWOTA'");
                }
                else
                {
                    transactionAmount = Convert.ToDouble(transactionAmountTxt);
                    sqlTransaction.AddTransaction(new Transaction(
                        transactionDate,
                        transactionPersonId,
                        transactionAmount,
                        transactionDescription,
                        transactionTarget,
                        transactionPayIn
                        ));

                    PayOutDatePicker.Text = "";
                    ComboBoxAddTransactionPayer.SelectedItem = null;
                    ComboBoxAddTransactionTarget.SelectedItem = null;
                    TxtAddTransactionAmount.Text = "";
                    TxtAddTransactionDescription.Text = "";
                    MessageBox.Show("ZAKSIĘGOWANO WYPŁATĘ: " + transactionAmount.ToString() + " ZŁ");
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
    }
}
