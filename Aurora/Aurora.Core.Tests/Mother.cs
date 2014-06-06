using System;
using System.Collections.Generic;
using Aurora.Core.Models.ProductModels;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;
using Aurora.Core.Exceptions;
using Aurora.Engine.Shipping;

namespace Aurora.Core.Tests
{
    public static class Mother
    {
        public static RegularCustomer GetCustomer1()
        {
            return new RegularCustomer
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Li",
                Username = "tomli",
                DateJoined = new DateTime(2014, 5, 1),
                IsStudent = true,
                ShippingAddress = Get1Address(),
                CreditCards = GetCreditCards()
            };
        }

        public static List<CreditCard> GetCreditCards()
        {
            var cards = new List<CreditCard>();
            cards.Add(GetCreditCard1());
            cards.Add(GetCreditCard2());
            return cards;
        }

        public static CreditCard GetCreditCard1()
        {
            return new CreditCard()
            {
                Id = 1,
                Number = "012345",
                CardType = ECreditCardType.Visa,
                TotalChargedAmount = 1000
            };
        }

        public static CreditCard GetCreditCard2()
        {
            return new CreditCard()
            {
                Id = 2,
                Number = "9876512",
                CardType = ECreditCardType.Master,
                TotalChargedAmount = 2000
            };
        }

        public static Address Get1Address()
        {
            return new Address()
            {
                Id = 1,
                Street = "East Street",
                City = "Rockville",
                State = "MD",
                Zip = "20852"
            };
        }

        public static InventoryProduct GetProduct1()
        {
            return new InventoryProduct()
            {
                Id = 1,
                Name = "Sony A7",
                Category = GetCameraCategory(),
                Description = "Mirrorless Compact Digital Camera",
                RetailPrice = 1599.99m
            };
        }

        public static InventoryProduct GetProduct2()
        {
            return new InventoryProduct()
            {
                Id = 2,
                Name = "Lenovo Y400",
                Category = GetComputerCategory(),
                Description = "Lenovo Laptop Computer",
                RetailPrice = 899.99m
            };
        }

        public static InventoryProduct GetProduct3()
        {
            return new InventoryProduct()
            {
                Id = 3,
                Name = "Cisco Phone 7945",
                Category = GetComputerCategory(),
                Description = "Cisco IP Phone",
                RetailPrice = 95.00m
            };
        }

        public static ProductCategory GetCameraCategory()
        {
            return new ProductCategory()
            {
                Id = 1,
                Name = "Camera"
            };
        }

        public static ProductCategory GetComputerCategory()
        {
            return new ProductCategory()
            {
                Id = 2,
                Name = "Computer"
            };
        }

        public static ProductCategory GetPhoneCategory()
        {
            return new ProductCategory()
            {
                Id = 3,
                Name = "Phone"
            };
        }

        public static CustomerOrder GetCustomerOrderInProcessing1()
        {
            var cart = new ShoppingCart();
            cart.Add(GetProduct1(), 3);
            cart.Add(GetProduct2(), 2);

            var buyer = GetCustomer1();
            var shippingMethod = new StandardShipping();
            var paymentMethod = GetCreditCard1();

            return new CustomerOrder
            {
                Id = 1,
                OrderDateTime = System.DateTime.Now.AddDays(1),
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
