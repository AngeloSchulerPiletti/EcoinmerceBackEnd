using Ecoinmerce.Domain.Entities.Purchase;
using Ecoinmerce.Domain.Objects.DTO.PurchaseDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;

namespace Ecoinmerce.Infra.Repository.Interfaces
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
