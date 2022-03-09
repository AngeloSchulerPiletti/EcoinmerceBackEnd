using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.Entities.Purchase
{
    public class Purchase
    {
        //private List<string> statusList = new() { "Paid", "Noticed", "Waiting Payment" };
        public Purchase()
        {
            this.PurchaseChecks = new HashSet<PurchaseCheck>();
        }

        public long Id { get; set; }
        public string PurchaseIdentifier { get; set; }
        public long PurchaseAmountInEther { get; set; }
        public string EcommerceWalletAddress { get; set; }
        public string CostumerWalletAddress { get; set; }
        public DateTime DateTimePurchaseNotice { get; set; }
        public DateTime DateTimePurchasePayment { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public virtual ICollection<PurchaseCheck> PurchaseChecks { get; set; }
    }
}
