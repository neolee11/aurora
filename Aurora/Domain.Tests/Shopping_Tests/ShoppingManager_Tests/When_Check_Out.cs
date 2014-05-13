using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Shopping;

namespace Domain.Tests.Shopping_Tests.ShoppingManager_Tests
{
    [TestClass]
    public class When_Check_Out
    {
        [TestMethod]
        public void Check_out_should_be_successful()
        {
            var customer = Mother.GetCustomer1();
            var manager = new ShoppingManager(customer);
            var shoppingCart = manager.ShoppingCart;
            shoppingCart.Add(Mother.GetProduct1(), 2);
            shoppingCart.Add(Mother.GetProduct2(), 3);

            var checkoutSetting = new CheckOutSetting()
            {
                CreditCardId = 1,
                ShippingMethod = new StandardShipping()
            };

            var result = manager.CheckOut(checkoutSetting);

            Assert.AreEqual(true, result);
        }
    }
}
