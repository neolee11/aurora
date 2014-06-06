using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Contracts.Business;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;
using Aurora.Core.Services;

namespace Aurora.Core.Exceptions
{
    public static class CustomerOrderService
    {
        public static CustomerOrder GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public static void CheckoutShoppingCart(IPurchaseItemList purchaseItemList, CustomerBase customer, IPaymentMethod payment, IShippingMethod shippingMethod)
        {
            var customerOrder = new CustomerOrder();
            customerOrder.OrderDateTime = DateTime.Now;
            purchaseItemList.Items.ForEach(i => customerOrder.Items.Add(i.Clone()));
            customerOrder.Customer = customer;
            customerOrder.Status = EOrderStatus.Processing;
            customerOrder.ShippingMethod = shippingMethod.MethodName();
            customerOrder.PaymentMethod = payment.PaymentName();
            customerOrder.ProductCost = purchaseItemList.GetTotalPrice();
            if (customer is PrimeCustomer)
            {
                customerOrder.ShippingCost = 0;
            }
            else
            {
                customerOrder.ShippingCost = shippingMethod.CalculatePrice();
            }
            customerOrder.TotalCost = customerOrder.ProductCost + customerOrder.ShippingCost;

            payment.Charge(customerOrder.TotalCost);

            //todo : persist order 
        }

        public static void ShipOrder(int orderId)
        {
            var order = GetOrderById(orderId);

            order.Status = EOrderStatus.Shipped;

            //todo : persist order
        }

        public static void CancelOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order.Status == EOrderStatus.Shipped)
            {
                throw new ShippedOrderCanNotBeCancelledException();
            }

            if (order.Status == EOrderStatus.Processing)
            {
                order.Status = EOrderStatus.Cancelled;
                //todo: persist order

                var paymentMethod = PaymentMethodFactory.GetPaymentMethod(order.PaymentMethod);
                paymentMethod.Refund(order.TotalCost);
            }
            
        }

    }
}
