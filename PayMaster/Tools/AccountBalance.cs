using PayMaster.SQL;

namespace PayMaster.Tools
{
    public class AccountBalance
    {
        SQLTransaction sqlTransaction = new SQLTransaction();

        public double accountBalanceValue { get; set; }
        public AccountBalance()
        {
            accountBalanceValue = sqlTransaction.GetAccountBalance();

        }

    }
}
