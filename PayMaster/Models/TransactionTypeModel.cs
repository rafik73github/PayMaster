using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster.Models
{
    class TransactionTypeModel
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeDescription { get; set; }
        public int TransactionTypeValue { get; set; }

        public TransactionTypeModel(int transactionTypeId, string transactionTypeDescription, int transactionTypeValue)
        {
            this.TransactionTypeId = transactionTypeId;
            this.TransactionTypeDescription = transactionTypeDescription;
            this.TransactionTypeValue = transactionTypeValue;
        }

        public TransactionTypeModel(string transactionTypeDescription, int transactionTypeValue)
        {
            this.TransactionTypeDescription = transactionTypeDescription;
            this.TransactionTypeValue = transactionTypeValue;
        }
    }
}
