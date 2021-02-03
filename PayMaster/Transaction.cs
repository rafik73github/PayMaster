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
        public double TransactionAmount { get; set; }  //kwota
        public string TransactionDescription { get; set; } //opis
        public bool TransactionPayIn { get; set; } // wpłata?


        public Transaction(int transactionId,
            string transactionDate,
            int transactionPersonId,
            string transactionPersonName,
            double transactionAmount,
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
            double transactionAmount,
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
            double transactionAmount,
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
