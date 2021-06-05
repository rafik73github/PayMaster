using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using PayMaster.SQL;
using PayMaster.Tools;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy Payers.xaml
    /// </summary>
    public partial class Payers : Window
    {
        



        private readonly SQLPerson sqlPerson = new SQLPerson();
        
        private string tempPersonName;
        private string tempPersonSurname;
        private string tempPersonNick;
        public Payers()
        {
            InitializeComponent();

            PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
            TxtAddPayerSurname.PreviewTextInput += ValidateText.LetterValidatinTextBox;
        }

        

        private void PayersBtnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void PayersBtnSave_Click(object sender, RoutedEventArgs e)
        {
            string payerAddNameText = TxtAddPayerName.Text.Trim().ToUpper();
            string payerAddSurnameText = TxtAddPayerSurname.Text.Trim().ToUpper();
            string payerAddNickText = TxtAddPayerNick.Text.Trim().ToUpper();

            string[] payerNameSolo = payerAddNameText.Split(' ');
            string[] payerSurnameSolo = payerAddSurnameText.Split(' ');

            
            if (payerAddNameText.Equals("") && payerAddSurnameText.Equals("") && payerAddNickText.Equals(""))
            {

                MessageBox.Show("WYPEŁNIJ PRZYNAJNIEJ\nJEDNO POLE");
              

            }
            else if (payerNameSolo.Length > 1)
            {
                MessageBox.Show("WPISZ POJEDYŃCZE IMIĘ");
            }
            else if (payerSurnameSolo.Length > 1)
            {
                MessageBox.Show("WPISZ POJEDYŃCZE NAZWISKO\nJEŚLI JEST WIELOCZŁONOWE,\nODDZIEL JE MYŚLNIKIEM");
            }
            else if(sqlPerson.IsPersonExist(payerAddNameText, payerAddSurnameText, payerAddNickText))
            {
                MessageBox.Show("TAKI PŁATNIK JUŻ ISTNIEJE");
            }
            else
            {
                sqlPerson.AddPerson(new PersonModel(payerAddNameText, payerAddSurnameText, payerAddNickText, false));

                TxtAddPayerName.Text = "";
                TxtAddPayerSurname.Text = "";
                TxtAddPayerNick.Text = "";

                PayersGrid.ItemsSource = null;
                PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
            }
        }

        private void PayersGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // PersonModel tempPerson = PayersGrid.SelectedItem as PersonModel;
            // if (tempPerson != null)
            if (PayersGrid.SelectedItem is PersonModel tempPerson)
            {
                tempPersonName = tempPerson.PersonName;
                tempPersonSurname = tempPerson.PersonSurname;
                tempPersonNick = tempPerson.PersonNick;

            }
            

        }

        private void PayersGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            PersonModel person = PayersGrid.SelectedItem as PersonModel;
            
            if (!person.PersonName.Equals(tempPersonName) || !person.PersonSurname.Equals(tempPersonSurname) || !person.PersonNick.Equals(tempPersonNick))
            {

                MessageBoxResult result = MessageBox.Show("ZAPISAĆ ZMIANY?", "ZAPIS ZMIAN W TABELI PŁATNIKÓW", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        
                        sqlPerson.UpdatePerson(person);
                        PayersGrid.ItemsSource = null;
                        PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
                        break;
                    case MessageBoxResult.Cancel:
                        
                        PayersGrid.ItemsSource = null;
                        PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
                        
                        break;

                }

            }
        }
    }
}
