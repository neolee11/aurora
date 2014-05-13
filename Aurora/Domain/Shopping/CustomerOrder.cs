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

        public int UserId
        {
            get
            {
                return _customer.Id;
            }
        }

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

        public Customer Customer
        {
            get
            {
                return _customer;
            }
        }
        #endregion

        #region Private Members

        private IShippingMethod _shippingMethod;
        private Customer _customer;
        private CreditCard _chargingCreditCard;
        private E_OrderStatus _status;
        #endregion

        public CustomerOrder(List<PurchaseItem> orderItems, IShippingMethod shippingMethod, Customer buyer, CreditCard buysCreditCard)
        {
            Items = new List<PurchaseItem>();
            orderItems.ForEach(i => Items.Add(i.Clone()));

            _shippingMethod = shippingMethod;
            _customer = buyer;
            _chargingCreditCard = buysCreditCard;
        }

        public void Process()
        {
            _status = E_OrderStatus.Processing;
            ChargeCreditCard();
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
