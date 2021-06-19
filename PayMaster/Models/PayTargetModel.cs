
namespace PayMaster
{
    internal class PayTargetModel
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
            PayTargetId = payTargetId;
            PayTargetText = payTargetText;
            PayTargetArchived = payTargetArchived;
        }

        public PayTargetModel
            (
            int payTargetId,
            string payTargetText

            )
        {
            PayTargetId = payTargetId;
            PayTargetText = payTargetText;

        }

        public PayTargetModel
            (
            string payTargetText,
            bool payTargetArchived
            )
        {
            PayTargetText = payTargetText;
            PayTargetArchived = payTargetArchived;
        }

    }
}
