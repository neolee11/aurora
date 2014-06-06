using System;
using Aurora.Core.Contracts.Business;
using Aurora.Core.Exceptions;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.Core.Services
{
    public static class CustomerOrderService
    {
        public static CustomerOrder GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check out a shopping cart
        /// </summary>
        /// <param name="purchaseItemList"></param>
        /// <param name="customer"></param>
        /// <param name="payment"></param>
        /// <param name="shippingMethod"></param>
        public static CustomerOrder Checkout(IPurchaseItemList purchaseItemList, CustomerBase customer, IPaymentMethod payment, IShippingMethod shippingMethod)
        {
            var customerOrder = new CustomerOrder();
            customerOrder.OrderDateTime = DateTime.Now;
            purchaseItemList.Items.ForEach(i => customerOrder.Items.Add(i.Clone()));
            customerOrder.Customer = customer;
            customerOrder.Status = EOrderStatus.Processing;
            customerOrder.ShippingMethod = shippingMethod.MethodName();
            customerOrder.PaymentMethod = payment.PaymentName();
            customerOrder.ProductCost = purchaseItemList.GetTotalPrice();
            customerOrder.ShippingCost = GetShippingCost(customer, shippingMethod);
            customerOrder.TotalCost = customerOrder.ProductCost + customerOrder.ShippingCost;

            payment.Charge(customerOrder.TotalCost);

            //todo : persist order 

            return customerOrder;
        }

        private static decimal GetShippingCost(CustomerBase customer, IShippingMethod shippingMethod)
        {
            if (customer is PrimeCustomer)
            {
                return 0;
            }
            else
            {
                return shippingMethod.CalculatePrice();
            }
        }

        public static void ShipOrder(int orderId)
        {
            ShipOrder(GetOrderById(orderId));
        }

        public static void ShipOrder(CustomerOrder order)
        {
            order.Status = EOrderStatus.Shipped;

            //todo : persist order
        }

        public static void CancelOrder(int orderId)
        {
            CancelOrder(GetOrderById(orderId));
        }

        public static void CancelOrder(CustomerOrder order)
        {
            if (order == null)
            {
                throw new Exception("Order is not set in CancelOrder method.");
            }

            if (order.Status == EOrderStatus.Shipped)
            {
                throw new ShippedOrderCanNotBeCancelledException();
            }

            if (order.Status == EOrderStatus.Processing)
            {
                order.Status = EOrderStatus.Cancelled;
                //todo: persist order

                //todo: refund payment
                //var paymentMethod = PaymentMethodFactory.GetPaymentMethod(order.PaymentMethod);
                //paymentMethod.Refund(order.TotalCost);
            }
        }
    }
}
