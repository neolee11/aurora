using Domain.Shopping.Shipping;
using Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public class ShoppingService
    {
        #region Private Members
        private ShoppingCart _shoppingCart;
        private Customer _customer;
        private CreditCard _chargingCreditCard;
        private IShippingMethod _shippingMethod;
        #endregion

        #region Properties

        public ShoppingCart ShoppingCart
        {
            get
            {
                return _shoppingCart;
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

        public ShoppingService(Customer customer)
        {
            _customer = customer;
            _shoppingCart = new ShoppingCart();
        }

        public bool CheckOut(CheckOutSetting checkoutSetting)
        {
            try
            {
                if (_shoppingCart.IsEmpty())
                    return false;

                if (SetPayingCreditCard(checkoutSetting.CreditCardId) == false)
                    return false;


                SetShippingMethod(checkoutSetting.ShippingMethod);

                var order = new CustomerOrder(
                    _shoppingCart.Items,
                    _shippingMethod,
                    _customer,
                    _chargingCreditCard
                    );

                order.Process();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SetPayingCreditCard(int creditCardId)
        {
            _chargingCreditCard = _customer.CreditCards.Where(c => c.Id == creditCardId).SingleOrDefault();

            if (_chargingCreditCard == null)
                return false;
            else
                return true;
        }

        private void SetShippingMethod(IShippingMethod shippingMethod)
        {
            _shippingMethod = shippingMethod;
        }

    }
}
