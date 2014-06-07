using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Services;
using Aurora.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Services_Tests.CustomerOrderService_Tests
{
    [TestClass]
    public class When_Cancel_Order
    {
        [TestMethod, TestCategory("Core.CustomerOrderService")]
        public void Cancel_order_should_make_order_in_canceled_status()
        {
            CustomerOrder order = CustomerOrderMother.GetCustomerOrderInProcessing1();

            CustomerOrderService.CancelOrder(order);

            Assert.AreEqual((object) EOrderStatus.Cancelled, order.Status);
        }

        [TestMethod, TestCategory("Core.CustomerOrderService")]
        public void Cancel_already_cancelled_order_should_have_no_impact()
        {
            CustomerOrder order = CustomerOrderMother.GetCustomerOrderInProcessing1();
            order.Status = EOrderStatus.Cancelled;

            CustomerOrderService.CancelOrder(order);

            Assert.AreEqual((object) EOrderStatus.Cancelled, order.Status);
        }
    }
}