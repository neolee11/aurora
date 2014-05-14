using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Shopping;

namespace Domain.Tests.Shopping_Tests.CustomerOrder_Tests
{
    [TestClass]
    public class When_Cancel_Order
    {
        [TestMethod]
        public void Cancel_order_should_make_order_in_canceled_status()
        {
            var order = Mother.GetCustomerOrder1();
            order.Process();
            order.Cancel();

            Assert.AreEqual(E_OrderStatus.Cancelled, order.Status);
        }

        [TestMethod]
        public void Cancel_completed_order_or_cancelled_order_should_have_no_impact()
        {
            var order = Mother.GetCustomerOrder1();
            order.Process();
            order.Ship();

            order.Cancel();

            Assert.AreEqual(E_OrderStatus.Shipped, order.Status);
        }
    }
}
