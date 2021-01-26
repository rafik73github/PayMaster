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
using System.Windows.Shapes;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy Payers.xaml
    /// </summary>
    public partial class Payers : Window
    {
        SQLPerson sqlPerson = new SQLPerson();
        public Payers()
        {
            InitializeComponent();

            PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
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

            
            if (payerAddNameText.Equals("") || payerAddSurnameText.Equals("")){

                MessageBox.Show("WYPEŁNIJ WSZYSTKIE POLA !");
              

            }
            else if(sqlPerson.IsPersonExist(payerAddNameText, payerAddSurnameText))
            {
                MessageBox.Show("TAKI PŁATNIK JUŻ ISTNIEJE");
            }
            else
            {
                sqlPerson.AddPerson(new Person(payerAddNameText, payerAddSurnameText, false));

                TxtAddPayerName.Text = "";
                TxtAddPayerSurname.Text = "";

                PayersGrid.ItemsSource = null;
                PayersGrid.ItemsSource = sqlPerson.GetAllPersons();
            }
        }
    }
}
