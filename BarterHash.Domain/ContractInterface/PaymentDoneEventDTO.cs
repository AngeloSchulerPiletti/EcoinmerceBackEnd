using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.ContractInterface
{
    [Event("PaymentDone")]
    public class PaymentDoneEventDTO : IEventDTO
    {
        [Parameter("address", "ecommerceWallet", 1, true)]
        public string EcommerceWallet { get; set; }

        [Parameter("uint", "paymentAmount", 2)]
        public long PaymentAmount { get; set; }

        [Parameter("string", "purchaseIdentifier", 3)]
        public string PurchaseIdentifier { get; set; }
    }
}
