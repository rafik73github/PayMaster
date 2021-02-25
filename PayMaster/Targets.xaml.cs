using System.Windows;
using System.Windows.Controls;
using PayMaster.SQL;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy Targets.xaml
    /// </summary>
    public partial class Targets : Window
    {

        private readonly SQLPayTarget sqlPayTarget = new SQLPayTarget();
        public Targets()
        {
            InitializeComponent();

            TargetsGrid.ItemsSource = sqlPayTarget.GetAllPayTargets();
        }

        private void TargetBtnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void TargetBtnSave_Click(object sender, RoutedEventArgs e)
        {

            string addTargetTxt = TxtAddTarget.Text.Trim().ToUpper();

            if (addTargetTxt.Equals(""))
            {

                MessageBox.Show("POLĘ 'CEL'\n MUSI BYĆ WYPEŁNIONE");


            }
            else if (sqlPayTarget.IsTargetExist(addTargetTxt))
            {
                MessageBox.Show("TAKI CEL JUŻ ISTNIEJE");
            }
            else
            {
                sqlPayTarget.AddPayTarget(new PayTargetModel(addTargetTxt, false));

                TxtAddTarget.Text = "";
                
                TargetsGrid.ItemsSource = null;
                TargetsGrid.ItemsSource = sqlPayTarget.GetAllPayTargets();
            }

        }

        private void TargetsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
        }

        private void TargetsGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        { 
        }

        
    }
}