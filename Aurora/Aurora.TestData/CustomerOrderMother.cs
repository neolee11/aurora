using System;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Engine.Shipping;

namespace Aurora.TestData
{
    public class CustomerOrderMother
    {
        public static CustomerOrder GetCustomerOrderInProcessing1()
        {
            var cart = new ShoppingCart();
            cart.Add(ProductMother.GetProduct1(), 3);
            cart.Add(ProductMother.GetProduct2(), 2);

            var buyer = CustomerMother.GetCustomer1();
            var shippingMethod = new StandardShipping();
            var paymentMethod = CreditCardsMother.GetCreditCard1();

            return new CustomerOrder
            {
                Id = 1,
                OrderDateTime = DateTime.Now.AddDays(1),
                Items = cart.Items,
                Customer = buyer,
                Status = EOrderStatus.Processing,
                ShippingMethod = shippingMethod.MethodName(),
                PaymentMethod = paymentMethod.PaymentName(),
                ProductCost = 200,
                ShippingCost = shippingMethod.CalculatePrice(),
                TotalCost = 200 + shippingMethod.CalculatePrice()
            };

        }
    }
}