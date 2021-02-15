using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    public class AccountBalance
    {
        SQLTransaction sqlTransaction = new SQLTransaction();

        public double accountBalanceValue { get; set; }
        public AccountBalance()
        {
            accountBalanceValue = sqlTransaction.getAccountBalance();

        }

    }
}
