using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    class PayTarget
    {
        public int PayTargetId { get; set; }
        public string PayTargetText { get; set; }
        public bool PayTargetArchived { get; set; }

        public PayTarget
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

        public PayTarget
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
