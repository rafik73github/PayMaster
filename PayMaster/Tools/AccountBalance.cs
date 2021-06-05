using PayMaster.SQL;
using System.Windows.Controls;

namespace PayMaster.Tools
{
    public class AccountBalance
    {
        private readonly double payInSum = 0;
        private readonly double payOutSum = 0;
        private readonly int payInCount = 0;
        private readonly int payOutCount = 0;
        private readonly double viewBalance = 0;
        private readonly SQLTransaction sqlTransaction = new SQLTransaction();

        public double AccountBalanceValue { get; set; }
        public double PayInBalanceValue { get; set; }
        public double PayOutBalanceValue { get; set; }
        public double ViewBalanceValue { get; set; }
        public string PayInCountOps { get; set; }
        public string PayOutCountOps { get; set; }


        public AccountBalance(DataGrid dataGrid)
        {
            AccountBalanceValue = sqlTransaction.GetAccountBalance();

            foreach (TransactionModel transactionModel in dataGrid.ItemsSource)
            {
                if (transactionModel.TransactionAmount > 0)
                {
                    payInSum += transactionModel.TransactionAmount;
                    payInCount++;
                }
                else
                {
                    payOutSum += transactionModel.TransactionAmount;
                    payOutCount++;
                }
            }
            PayInBalanceValue = payInSum;
            PayOutBalanceValue = payOutSum;
            ViewBalanceValue = payInSum + payOutSum;

            PayInCountOps = "(x" + payInCount + ")";
            PayOutCountOps = "(x" + payOutCount + ")"; ;
        }

    }
}
