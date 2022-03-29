using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.Objects.DTO
{
    public class PurchaseEventFailDTO
    {
        public PurchaseEventFailDTO(string logAddress = null, string blockHash = null, string transactionHash = null, string observation = null)
        {
            LogAddress = logAddress;
            BlockHash = blockHash;
            TransactionHash = transactionHash;
            Observation = observation;
        }

        public string LogAddress { get; set; }
        public string BlockHash { get; set; }
        public string TransactionHash { get; set; }
        public string Observation { get; set; }
    }
}
