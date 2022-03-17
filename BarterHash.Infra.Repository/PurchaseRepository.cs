using AutoMapper;
using BarterHash.Domain.Entities.Purchase;
using BarterHash.Domain.Objects.DTO;
using BarterHash.Domain.Objects.VO;
using BarterHash.Infra.Repository.Database.Context;
using BarterHash.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarterHash.Infra.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly PurchaseContext _context;
        private readonly IMapper _mapper;

        public PurchaseRepository(PurchaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public MessageBagVO DeletePurchase(long purchaseId)
        {
            throw new NotImplementedException();
        }

        public MessageBagVO DeletePurchase(string purchaseIdentifier, string ecommerceWalletAddress)
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchase(long purchaseId)
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchase(string purchaseIdentifier, string ecommerceWalletAddress)
        {
            throw new NotImplementedException();
        }

        public Purchase IncreasePurchaseCheckOverCounter(long purchaseId)
        {
            throw new NotImplementedException();
        }

        public Purchase SavePaymentEvent(PaymentEventDTO paymentDoneDTO)
        {
            try
            {
                Purchase purchase = _mapper.Map<Purchase>(paymentDoneDTO);
                purchase.PurchaseEvent = new(DateTime.Now, paymentDoneDTO.PurchaseAmountPaidInEther);
                purchase.PurchaseCheck = new();
                _context.Purchases.Add(purchase);
                _context.SaveChanges();
                return purchase;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Purchase SavePaymentNotice(PaymentNoticeDTO paymentNoticeDTO)
        {
            throw new NotImplementedException();
        }

        public PurchaseEventFail SavePurchaseEventFail(PurchaseEventFailDTO purchaseEventFailDTO)
        {
            try
            {
                PurchaseEventFail purchaseEventFail = _mapper.Map<PurchaseEventFail>(purchaseEventFailDTO);
                _context.PurchaseEventFails.Add(purchaseEventFail);
                _context.SaveChanges();
                return purchaseEventFail;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
