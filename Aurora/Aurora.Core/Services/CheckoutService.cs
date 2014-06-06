using System;
using System.Globalization;
using System.Linq;
using Aurora.Core.Contracts.Business;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.Core.Exceptions
{
    //public class CheckoutService
    //{
    //    #region Private Fields
    //    private ShoppingCart _shoppingCart;
    //    private CustomerBase _customer;
    //    private CreditCard _chargingCreditCard;
    //    private IShippingMethod _shippingMethod;
    //    #endregion

    //    #region Properties

    //    public ShoppingCart ShoppingCart
    //    {
    //        get
    //        {
    //            return _shoppingCart;
    //        }
    //    }

    //    public CustomerBase Customer
    //    {
    //        get
    //        {
    //            return _customer;
    //        }
    //    }

    //    #endregion

    //    #region Contructors

    //    public CheckoutService(CustomerBase customer)
    //    {
    //        _customer = customer;
    //        _shoppingCart = new ShoppingCart();
    //    }

    //    #endregion

    //    #region Public APIs

    //    public bool CheckOut(CheckOutSetting checkoutSetting)
    //    {
    //        try
    //        {
    //            if (_shoppingCart.IsEmpty())
    //                return false;

    //            if (SetPayingCreditCard(checkoutSetting.CreditCardId) == false)
    //                return false;


    //            SetShippingMethod(checkoutSetting.ShippingMethod);

    //            var order = new TestCustomerOrder(
    //                _shoppingCart.Items,
    //                _shippingMethod,
    //                _customer,
    //                _chargingCreditCard
    //                );

    //            order.Process();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    #endregion

    //    #region Private Methods

    //    private bool SetPayingCreditCard(int creditCardId)
    //    {
    //        _chargingCreditCard = _customer.CreditCards.Where(c => c.Id == creditCardId).SingleOrDefault();

    //        if (_chargingCreditCard == null)
    //            return false;
    //        else
    //            return true;
    //    }

    //    private void SetShippingMethod(IShippingMethod shippingMethod)
    //    {
    //        _shippingMethod = shippingMethod;
    //    }

    //    #endregion
    //}
}
