using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    class Transaction
    {

        public int TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public int TransactionPersonId { get; set; }
        public int TransactionAmount { get; set; }
        public bool TransactionPayIn { get; set; }


        public Transaction(int transactionId, string transactionDate, int transactionPersonId, int transactionAmount, bool transactionPayIn)
        {
            this.TransactionId = transactionId;
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionAmount = transactionAmount;
            this.TransactionPayIn = transactionPayIn;
        }
    }
}
