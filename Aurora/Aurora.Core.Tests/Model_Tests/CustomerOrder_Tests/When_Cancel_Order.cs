using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Model_Tests.CustomerOrder_Tests
{
    [TestClass]
    public class When_Cancel_Order
    {
        [TestMethod, TestCategory("Core.CustomerOrder")]
        public void Cancel_order_should_make_order_in_canceled_status()
        {
            TestCustomerOrder order = Mother.GetCustomerOrder1();

            order.Process();
            order.Cancel();

            Assert.AreEqual((object) EOrderStatus.Cancelled, order.Status);
        }

        [TestMethod, TestCategory("Core.CustomerOrder")]
        public void Cancel_completed_order_or_cancelled_order_should_have_no_impact()
        {
            TestCustomerOrder order = Mother.GetCustomerOrder1();
            order.Process();
            order.Ship();

            order.Cancel();

            Assert.AreEqual((object) EOrderStatus.Shipped, order.Status);
        }
    }
}