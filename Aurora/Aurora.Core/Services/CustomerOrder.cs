using System.Collections.Generic;
using System.Linq;
using Aurora.Core.Contracts.Shopping;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserModels;

namespace Aurora.Core.Services
{
    public class CustomerOrder
    {
        #region Properties

        public int Id { get; set; }

        public int UserId
        {
            get { return Customer.Id; }
        }

        public List<PurchaseItem> Items { get; set; }

        public EOrderStatus Status
        {
            get { return _status; }
        }

        public decimal TotalProductPrice
        {
            get
            {
                return Items.Sum(item => item.Product.Price*item.Quantity);
            }
        }

        public decimal ShippingFee
        {
            get { return _shippingMethod.CalculatePrice(); }
        }

        public decimal TotalPrice
        {
            get { return TotalProductPrice + ShippingFee; }
        }

        public CreditCard ChargingCreditCard
        {
            get { return _chargingCreditCard; }
        }

        public Customer Customer { get; set; }
       
        #endregion

        #region Private Members

        private readonly CreditCard _chargingCreditCard;
        //private readonly Customer _customer;
        private readonly IShippingMethod _shippingMethod;
        private EOrderStatus _status;

        #endregion

        public CustomerOrder(List<PurchaseItem> orderItems, IShippingMethod shippingMethod, Customer buyer,
            CreditCard buyersCreditCard)
        {
            Items = new List<PurchaseItem>();
            orderItems.ForEach(i => Items.Add(i.Clone()));

            _shippingMethod = shippingMethod;
            Customer = buyer;
            _chargingCreditCard = buyersCreditCard;
        }

        public void Process()
        {
            _status = EOrderStatus.Processing;
            ChargeCreditCard();
        }

        public void Ship()
        {
            _status = EOrderStatus.Shipped;
        }

        public void Cancel()
        {
            //Only allow cancel when the order is in processing state
            if (_status == EOrderStatus.Processing)
            {
                _status = EOrderStatus.Cancelled;
                RefundCreditCard();
            }
        }

        private void ChargeCreditCard()
        {
            if (_chargingCreditCard != null)
                _chargingCreditCard.Charge(TotalPrice);
        }

        private void RefundCreditCard()
        {
            if (_chargingCreditCard != null)
                _chargingCreditCard.Charge(-TotalPrice);
        }
    }
}