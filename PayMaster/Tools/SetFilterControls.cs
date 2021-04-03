using System;
using System.Collections.Generic;
using System.Windows.Controls;
using PayMaster.Models;
using PayMaster.SQL;
using PayMaster.TimeTools;

namespace PayMaster.Tools
{
    class SetFilterControls
    {
        private string firstDate;
        private string lastDate;

        public void SetCurrentFilterControls (DataGrid grid, DatePicker first, DatePicker last, ComboBox transaction, ComboBox target)
        {
            

            if(FilterModel.DateIndex == 0)
            {
                firstDate = "1970-01-01";
                lastDate = "2999-12-31";
            }
            else
            {
                firstDate = Convert.ToDateTime(first.Text).ToString("yyyy-MM-dd");
                lastDate = Convert.ToDateTime(last.Text).ToString("yyyy-MM-dd");
            }

            transaction.ItemsSource = TransactionTypeList();
            transaction.SelectedIndex = FilterModel.TransactionIndex;

            target.ItemsSource = new SQLPayTarget().GetPayTarget();
            target.SelectedIndex = FilterModel.TargetIndex;


            grid.ItemsSource = new SQLTransaction().GetFilteredTransactionList(
                firstDate,
                lastDate,
                TransactionTypeList()[transaction.SelectedIndex].TransactionTypeValue,
                new SQLPayTarget().GetPayTarget()[target.SelectedIndex].PayTargetId);
        }

        private List<TransactionTypeModel> TransactionTypeList()
        {
            List<TransactionTypeModel> result = new List<TransactionTypeModel>
            {
                new TransactionTypeModel(0, "WSZYSTKIE", -1),
                new TransactionTypeModel(1, "WPŁATY", 1),
                new TransactionTypeModel(2, "WYPŁATY", 0)
            };

            return result;
        }


    }
}
