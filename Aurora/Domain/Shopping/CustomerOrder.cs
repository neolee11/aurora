using Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public class CustomerOrder
    {
        #region Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<PurchaseItem> Items { get; set; }
        public E_OrderStatus Status
        {
            get
            {
                return _status;
            }
        }

        public decimal TotalProductPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Product.Price * item.Quantity;
                }
                return total;
            }
        }

        public decimal ShippingFee
        {
            get
            {
                return _shippingMethod.CalculatePrice();
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return TotalProductPrice + ShippingFee;
            }
        }

        public CreditCard ChargingCreditCard
        {
            get
            {
                return _chargingCreditCard;
            }
        }
        #endregion

        #region Private Members

        private IShippingMethod _shippingMethod;
        private Customer _buyer;
        private CreditCard _chargingCreditCard;
        private E_OrderStatus _status;
        #endregion

        public CustomerOrder(List<PurchaseItem> orderItems, IShippingMethod shippingMethod, Customer buyer, CreditCard buysCreditCard)
        {
            Items = new List<PurchaseItem>();
            orderItems.ForEach(i => Items.Add(i.Clone()));

            _shippingMethod = shippingMethod;
            _buyer = buyer;
            _chargingCreditCard = buysCreditCard;
            _status = E_OrderStatus.Processing;
        }

        public void Ship()
        {
            _status = E_OrderStatus.Shipped;
        }

        public void Cancel()
        {
            //Only allow cancel when the order is in processing state
            if (_status == E_OrderStatus.Processing)
            {
                _status = E_OrderStatus.Cancelled;
                RefundCreditCard();
            }
        }

        public void ChargeCreditCard()
        {
            if (_chargingCreditCard != null)
                _chargingCreditCard.Charge(TotalPrice);
        }

        public void RefundCreditCard()
        {
            if (_chargingCreditCard != null)
                _chargingCreditCard.Charge(-TotalPrice);
        }
    }
}
