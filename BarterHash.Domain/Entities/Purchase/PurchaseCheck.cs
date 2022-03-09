using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.Entities.Purchase
{
    public class PurchaseCheck
    {
        public long Id { get; set; }
        public int CheckOverCounter { get; set; } // Precisa contabilizar a cada busca no banco
        public long PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
