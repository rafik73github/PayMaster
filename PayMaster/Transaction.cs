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
        public string TransactionPersonName { get; set; }
        public string TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
        public bool TransactionPayIn { get; set; }


        public Transaction(int transactionId,
            string transactionDate,
            int transactionPersonId,
            string transactionPersonName,
            string transactionAmount,
            string transactionDescription,
            bool transactionPayIn)
        {
            this.TransactionId = transactionId;
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionPersonName = transactionPersonName;
            this.TransactionAmount = transactionAmount;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }

        public Transaction(string transactionDate,
            int transactionPersonId,
            string transactionPersonName,
            string transactionAmount,
            string transactionDescription,
            bool transactionPayIn)
        {
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionPersonName = transactionPersonName;
            this.TransactionAmount = transactionAmount;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }

        public Transaction(string transactionDate,
            int transactionPersonId,
            string transactionAmount,
            string transactionDescription,
            bool transactionPayIn)
        {
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionAmount = transactionAmount;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }
    }
}
