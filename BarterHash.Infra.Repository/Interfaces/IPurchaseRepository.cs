using BarterHash.Domain.Entities.Purchase;
using BarterHash.Domain.Objects.DTO;
using BarterHash.Domain.Objects.VO.Responses;

namespace BarterHash.Infra.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        public MessageBagVO DeletePurchase(long purchaseId);
        public MessageBagVO DeletePurchase(string purchaseIdentifier, string ecommerceWalletAddress);
        public Purchase GetPurchase(long purchaseId);
        public Purchase GetPurchase(string purchaseIdentifier, string ecommerceWalletAddress);
        public Purchase IncreasePurchaseCheckOverCounter(long purchaseId);
        public Purchase SavePaymentEvent(PaymentEventDTO paymentDoneDTO);
        public Purchase SavePaymentNotice(PaymentNoticeDTO paymentNoticeDTO);
        public PurchaseEventFail SavePurchaseEventFail(PurchaseEventFailDTO purchaseEventFailDTO);

    }
}
