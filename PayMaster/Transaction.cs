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
        public string TransactionPersonSurname { get; set; }
        public int TransactionAmount { get; set; }
        public bool TransactionPayIn { get; set; }


        public Transaction(int transactionId, string transactionDate, int transactionPersonId, string transactionPersonName, string transactionPersonSurname, int transactionAmount, bool transactionPayIn)
        {
            this.TransactionId = transactionId;
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionPersonName = transactionPersonName;
            this.TransactionPersonSurname = transactionPersonSurname;
            this.TransactionAmount = transactionAmount;
            this.TransactionPayIn = transactionPayIn;
        }
    }
}
