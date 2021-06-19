namespace PayMaster.Models
{
    internal class TransactionTypeModel
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeDescription { get; set; }
        public int TransactionTypeValue { get; set; }

        public TransactionTypeModel(int transactionTypeId, string transactionTypeDescription, int transactionTypeValue)
        {
            TransactionTypeId = transactionTypeId;
            TransactionTypeDescription = transactionTypeDescription;
            TransactionTypeValue = transactionTypeValue;
        }

        public TransactionTypeModel(string transactionTypeDescription, int transactionTypeValue)
        {
            TransactionTypeDescription = transactionTypeDescription;
            TransactionTypeValue = transactionTypeValue;
        }
    }
}
