using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Services;
using Aurora.Engine.Shipping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Model_Tests.CustomerOrder_Tests
{
    [TestClass]
    public class When_Create_Order
    {
        //here I can use mocks
        [TestMethod, TestCategory("Core.CustomerOrder")]
        public void Create_order_by_giving_shoppingcart_and_customer_and_creditcard_should_yield_a_successful_order()
        {
            var cart = new ShoppingCart();
            cart.Add(Mother.GetProduct1(), 3);
            cart.Add(Mother.GetProduct2(), 2);

            var buyer = Mother.GetCustomer1();

            var order = new CustomerOrder(
                cart.Items,
                new StandardShipping(),
                buyer,
                buyer.CreditCards[0]
            );

            //CollectionAssert.AreEquivalent(cart.Items, order.Items); //Does NOT work
            Assert.AreEqual(cart.TotalPrice, order.TotalProductPrice);
        }

        [TestMethod, TestCategory("Core.CustomerOrder")]
        public void Process_new_order_should_yield_an_order_in_processing_state()
        {
            var order = Mother.GetCustomerOrder1();
            order.Process();

            Assert.AreEqual((object)EOrderStatus.Processing, order.Status);
        }

        [TestMethod, TestCategory("Core.CustomerOrder")]
        public void Process_an_order_should_charge_customer_credit_card()
        {
            var order = Mother.GetCustomerOrder1();
            var card = order.ChargingCreditCard;
            var beforedAmount = card.TotalChargedAmount;
            var orderPrice = order.TotalPrice;

            order.Process();

            Assert.AreEqual((object)(beforedAmount + orderPrice), card.TotalChargedAmount);
        }

    }
}
