using Aurora.Core.Contracts.Business;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;
using Aurora.Core.Services;
using Aurora.Engine.Shipping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Services_Tests.CustomerOrderService_Tests
{
    [TestClass]
    public class When_Create_Order
    {
        //here I can use mocks
        [TestMethod, TestCategory("Core.CustomerOrderService")]
        public void Create_order_by_giving_shoppingcart_and_customer_and_creditcard_and_shippingmethod_should_yield_a_successful_order()
        {
            IPurchaseItemList shoppingCart = new ShoppingCart();
            shoppingCart.Add(Mother.GetProduct1(), 3);
            shoppingCart.Add(Mother.GetProduct2(), 2);
            CustomerBase customer = Mother.GetCustomer1();
            IPaymentMethod payeMethod = customer.CreditCards[0];
            IShippingMethod shippingMethod = new OvernightShipping();

            var customerOrder = CustomerOrderService.Checkout(shoppingCart, customer, payeMethod, shippingMethod);
           
            //CollectionAssert.AreEquivalent(cart.Items, order.Items); //Does NOT work
            Assert.AreEqual(shoppingCart.GetTotalPrice(), customerOrder.TotalCost - customerOrder.ShippingCost);
        }

        [TestMethod, TestCategory("Core.CustomerOrderService")]
        public void Checkout_shopping_cart_should_yield_an_order_in_processing_state()
        {
            IPurchaseItemList shoppingCart = new ShoppingCart();
            shoppingCart.Add(Mother.GetProduct1(), 3);
            shoppingCart.Add(Mother.GetProduct2(), 2);
            CustomerBase customer = Mother.GetCustomer1();
            IPaymentMethod payeMethod = customer.CreditCards[0];
            IShippingMethod shippingMethod = new OvernightShipping();

            var customerOrder = CustomerOrderService.Checkout(shoppingCart, customer, payeMethod, shippingMethod);

            Assert.AreEqual((object)EOrderStatus.Processing, customerOrder.Status);
        }

        [TestMethod, TestCategory("Core.CustomerOrderService")]
        public void Process_an_order_should_charge_customer_credit_card()
        {
            IPurchaseItemList shoppingCart = new ShoppingCart();
            shoppingCart.Add(Mother.GetProduct1(), 3);
            shoppingCart.Add(Mother.GetProduct2(), 2);
            CustomerBase customer = Mother.GetCustomer1();
            IPaymentMethod payeMethod = customer.CreditCards[0];
            IShippingMethod shippingMethod = new OvernightShipping();

            var beforedAmount = payeMethod.TotalChargedAmount;
            var customerOrder = CustomerOrderService.Checkout(shoppingCart, customer, payeMethod, shippingMethod);
            var orderTotalPrice = customerOrder.TotalCost;

            Assert.AreEqual((object)(beforedAmount + orderTotalPrice), payeMethod.TotalChargedAmount);
        }

    }
}
