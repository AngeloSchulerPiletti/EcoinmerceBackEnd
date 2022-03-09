using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.ContractInterface
{
    [Function("purchasePayment", "bool")]
    public class PurchasePaymentFunction : FunctionMessage
    {
        [Parameter("address", "ecommerceWallet", 1)]
        public string EcommerceWallet { get; set; }

        [Parameter("uint", "purchaseIdentifier", 2)]
        public long PurchaseIdentifier { get; set; }
    }
}
