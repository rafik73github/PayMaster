using System.Collections.Generic;

namespace PayMaster.Tools
{
    class FinancialOps
    {

        public double GetFilteredBalance(double payIn, double payOut)
        {
 
            return payIn + payOut;

        }

        public double GetPayIn(List<TransactionModel> transactionModel)
        {
            double sum = 0d;

            for (int i = 0; i < transactionModel.Count; i++)
            {
                if(transactionModel[i].TransactionAmount > 0)
                {
                    sum += transactionModel[i].TransactionAmount;
                }
            }

            return sum;
        }

        public double GetPayOut(List<TransactionModel> transactionModel)
        {
            double sum = 0d;

            for (int i = 0; i < transactionModel.Count; i++)
            {
                if (transactionModel[i].TransactionAmount < 0)
                {
                    sum += transactionModel[i].TransactionAmount;
                }
            }

            return sum;
        }

        public int GetFilteredBalanceCount(List<TransactionModel> transactionModel)
        {
            return transactionModel.Count;
        }

        public int GetPayInCount(List<TransactionModel> transactionModel)
        {
            int sum = 0;

            for (int i = 0; i < transactionModel.Count; i++)
            {
                if (transactionModel[i].TransactionAmount > 0)
                {
                    sum ++;
                }
            }

            return sum;
        }

        public int GetPayOutCount(List<TransactionModel> transactionModel)
        {
            int sum = 0;

            for (int i = 0; i < transactionModel.Count; i++)
            {
                if (transactionModel[i].TransactionAmount < 0)
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
