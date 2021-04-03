﻿using System;
using System.Collections.Generic;
using System.Windows;
using PayMaster.TimeTools;
using PayMaster.SQL;
using PayMaster.Tools;
using PayMaster.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PayMaster
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string tempTransactionDescription;
        readonly SetFilterControls setFilterControls = new SetFilterControls();
        readonly SQLTransaction sqlTransaction = new SQLTransaction();
        public MainWindow()
        {
            
            InitializeComponent();

            FirstDateFilter.Text = FilterModel.FirstDate.Trim();
            LastDateFilter.Text = FilterModel.LastDate.Trim();

                setFilterControls.SetCurrentFilterControls(
                MainGrid,
                FirstDateFilter,
                LastDateFilter,
                ComboBoxTransactionFilterSelect,
                ComboBoxTargetFilterSelect);

            

            DataContext = new AccountBalance();

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelRow_Click(object sender, RoutedEventArgs e)
        {
            TransactionModel transaction = MainGrid.SelectedItem as TransactionModel;
            int transationId = transaction.TransactionId;
            if (MessageBox.Show("NAPEWNO USUNĄĆ ZAZNACZONY WPIS ?!",
            "POTWIERDŹ USUNIĘCIE", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                sqlTransaction.DeleteTransaction(transationId);

                MainGrid.ItemsSource = null;
                setFilterControls.SetCurrentFilterControls(
            MainGrid,
            FirstDateFilter,
            LastDateFilter,
            ComboBoxTransactionFilterSelect,
            ComboBoxTargetFilterSelect);

                BtnDelRow.IsEnabled = false;
                DataContext = new AccountBalance();
            }
            else
            {
                // Do not close the window  
            }
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

        private void BtnFilterView_Click(object sender, RoutedEventArgs e)
        {
            if ((FirstDateFilter.Text.Equals("") && !LastDateFilter.Text.Equals(""))
                || (!FirstDateFilter.Text.Equals("") && LastDateFilter.Text.Equals("")))
            {
                MessageBox.Show("WYBIERZ OBYDWIE DATY !");
            }
            else
            {
                if(FirstDateFilter.Text.Equals("") && LastDateFilter.Text.Equals(""))
                {
                    FilterModel.DateIndex = 0;
                    FilterModel.FirstDate = "";
                    FilterModel.LastDate = "";
                    
                }
                else
                {
                    FilterModel.DateIndex = 1;
                    FilterModel.FirstDate = FirstDateFilter.Text;
                    FilterModel.LastDate = LastDateFilter.Text;
                    
                }
                

                FilterModel.TransactionIndex = ComboBoxTransactionFilterSelect.SelectedIndex;
                FilterModel.TargetIndex = ComboBoxTargetFilterSelect.SelectedIndex;

                setFilterControls.SetCurrentFilterControls(
                    MainGrid,
                    FirstDateFilter,
                    LastDateFilter,
                    ComboBoxTransactionFilterSelect,
                    ComboBoxTargetFilterSelect);


                BtnDelRow.IsEnabled = false;

            }

        }

        private void BtnFilterReset_Click(object sender, RoutedEventArgs e)
        {

            FilterModel.DateIndex = 0;
            FilterModel.FirstDate = "";
            FilterModel.LastDate = "";
            FilterModel.TransactionIndex = 0;
            FilterModel.TargetIndex = 0;

            FirstDateFilter.Text = FilterModel.FirstDate.Trim();
            LastDateFilter.Text = FilterModel.LastDate.Trim();

            setFilterControls.SetCurrentFilterControls(
                    MainGrid,
                    FirstDateFilter,
                    LastDateFilter,
                    ComboBoxTransactionFilterSelect,
                    ComboBoxTargetFilterSelect);

            BtnDelRow.IsEnabled = false;

        }

        private void FirstDateFilter_CalendarClosed(object sender, RoutedEventArgs e)
        {
            LastDateFilter.DisplayDateStart = FirstDateFilter.SelectedDate;

        }

        private void LastDateFilter_CalendarClosed(object sender, RoutedEventArgs e)
        {
            FirstDateFilter.DisplayDateEnd = LastDateFilter.SelectedDate;
        }
        
        private void MainGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            if (MainGrid.SelectedItem is TransactionModel transactionModel)
            {
                
                tempTransactionDescription = transactionModel.TransactionDescription;
                
            }
        }
        
        private void MainGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            TransactionModel transaction = MainGrid.SelectedItem as TransactionModel;
            
            if (!transaction.TransactionDescription.Equals(tempTransactionDescription))
            {

                MessageBoxResult result = MessageBox.Show("ZAPISAĆ ZMIANY?", "ZAPIS ZMIAN W TABELI GŁÓWNEJ", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:

                        sqlTransaction.UpdateTransactionDesription(transaction.TransactionId, transaction.TransactionDescription);
                        MainGrid.ItemsSource = null;
                        setFilterControls.SetCurrentFilterControls(
                    MainGrid,
                    FirstDateFilter,
                    LastDateFilter,
                    ComboBoxTransactionFilterSelect,
                    ComboBoxTargetFilterSelect);
                        break;

                    case MessageBoxResult.Cancel:

                        MainGrid.ItemsSource = null;
                        setFilterControls.SetCurrentFilterControls(
                    MainGrid,
                    FirstDateFilter,
                    LastDateFilter,
                    ComboBoxTransactionFilterSelect,
                    ComboBoxTargetFilterSelect);

                        break;

                }

            }

        }

        private void MainGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDelRow.IsEnabled = true;
           
        }

        


    }
}
