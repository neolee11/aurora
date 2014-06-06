//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Aurora.Core.Contracts.Business;
//using Aurora.Core.Models.UserAccountModels;

//namespace Aurora.Core.Models.ShoppingModels
//{
//    public class TestCustomerOrder
//    {

//        #region Properties

//        public int Id { get; set; } //Order ID

//        public List<PurchaseItem> Items { get; set; }

//        public EOrderStatus Status { get; private set; }

//        public decimal TotalProductPrice
//        {
//            get
//            {
//                return Items.Sum(item => item.Product.RetailPrice*item.Quantity);
//            }
//        }

//        public decimal ShippingFee
//        {
//            get { return _shippingMethod.CalculatePrice(); }
//        }

//        public decimal TotalPrice
//        {
//            get { return TotalProductPrice + ShippingFee; }
//        }

//        public CreditCard ChargingCreditCard
//        {
//            get { return _chargingCreditCard; }
//        }

//        public CustomerBase Customer { get; set; }

//        public DateTime OrderDateTime { get; set; }

//        #endregion

//        #region Private Members

//        private readonly IPaymentMethod _payment;
//        pri
//        private readonly IShippingMethod _shippingMethod;

//        #endregion

//        public TestCustomerOrder(List<PurchaseItem> orderItems, IShippingMethod shippingMethod, CustomerBase customer,
//            IPaymentMethod payment)
//        {
//            Items = new List<PurchaseItem>();
//            orderItems.ForEach(i => Items.Add(i.Clone()));

//            _shippingMethod = shippingMethod;
//            Customer = customer;
//            _payment = payment;
//        }


//        public void Process()
//        {
//            _status = EOrderStatus.Processing;
//            ChargeCreditCard();
//        }

//        public void Ship()
//        {
//            _status = EOrderStatus.Shipped;
//        }

//        public void Cancel()
//        {
//            //Only allow cancel when the order is in processing state
//            if (_status == EOrderStatus.Processing)
//            {
//                _status = EOrderStatus.Cancelled;
//                RefundCreditCard();
//            }
//        }

//        private void ChargeCreditCard()
//        {
//            if (_chargingCreditCard != null)
//                _chargingCreditCard.Charge(TotalPrice);
//        }

//        private void RefundCreditCard()
//        {
//            if (_chargingCreditCard != null)
//                _chargingCreditCard.Charge(-TotalPrice);
//        }
//    }
//}