

namespace PayMaster
{
    class TransactionModel
    {

        public int TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public int TransactionPersonId { get; set; }
        public string TransactionPersonName { get; set; }
        public string TransactionPersonSurname { get; set; }
        public string TransactionPersonNick { get; set; }
        public double TransactionAmount { get; set; }  //kwota
        public int TransactionTarget { get; set; }  //cel
        public string TransactionTargetText { get; set; }  //cel
        public string TransactionDescription { get; set; } //opis
        public bool TransactionPayIn { get; set; } // wpłata?


        public TransactionModel(int transactionId,
            string transactionDate,
            int transactionPersonId,
            string transactionPersonName,
            string transactionPersonSurname,
            string transactionPersonNick,
            double transactionAmount,
            int transactionTarget,
            string transactionTargetText,
            string transactionDescription,
            bool transactionPayIn)
        {
            this.TransactionId = transactionId;
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionPersonName = transactionPersonName;
            this.TransactionPersonSurname = transactionPersonSurname;
            this.TransactionPersonNick = transactionPersonNick;
            this.TransactionAmount = transactionAmount;
            this.TransactionTarget = transactionTarget;
            this.TransactionTargetText = transactionTargetText;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }

        public TransactionModel(string transactionDate,
            int transactionPersonId,
            string transactionPersonName,
            string transactionPersonSurname,
            string transactionPersonNick,
            double transactionAmount,
            int transactionTarget,
            string transactionTargetText,
            string transactionDescription,
            bool transactionPayIn)
        {
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionPersonName = transactionPersonName;
            this.TransactionPersonSurname = transactionPersonSurname;
            this.TransactionPersonNick = transactionPersonNick;
            this.TransactionAmount = transactionAmount;
            this.TransactionTarget = transactionTarget;
            this.TransactionTargetText = transactionTargetText;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }

        public TransactionModel(string transactionDate,
            int transactionPersonId,
            double transactionAmount,
            string transactionDescription,
            int transactionTarget,
            bool transactionPayIn)
        {
            this.TransactionDate = transactionDate;
            this.TransactionPersonId = transactionPersonId;
            this.TransactionAmount = transactionAmount;
            this.TransactionTarget = transactionTarget;
            this.TransactionDescription = transactionDescription;
            this.TransactionPayIn = transactionPayIn;
        }
    }
}
