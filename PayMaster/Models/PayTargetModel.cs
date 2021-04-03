
namespace PayMaster
{
    class PayTargetModel
    {
        public int PayTargetId { get; set; }
        public string PayTargetText { get; set; }
        public bool PayTargetArchived { get; set; }

        public PayTargetModel
            (
            int payTargetId,
            string payTargetText,
            bool payTargetArchived
            )
        {
            this.PayTargetId = payTargetId;
            this.PayTargetText = payTargetText;
            this.PayTargetArchived = payTargetArchived;
        }

        public PayTargetModel
            (
            int payTargetId,
            string payTargetText
            
            )
        {
            this.PayTargetId = payTargetId;
            this.PayTargetText = payTargetText;
            
        }

        public PayTargetModel
            (
            string payTargetText,
            bool payTargetArchived
            )
        {
            this.PayTargetText = payTargetText;
            this.PayTargetArchived = payTargetArchived;
        }

    }
}
