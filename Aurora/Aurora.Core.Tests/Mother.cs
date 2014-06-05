using System;
using System.Collections.Generic;
using Aurora.Core.Models.ProductModels;
using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;
using Aurora.Core.Services;
using Aurora.Engine.Shipping;

namespace Aurora.Core.Tests
{
    public static class Mother
    {
        public static Customer GetCustomer1()
        {
            return new Customer
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Li",
                Username = "tomli",
                DateJoined = new DateTime(2014, 5, 1),
                IsMarried = true,
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
                CardType = E_CreditCardType.Visa
            };
        }

        public static CreditCard GetCreditCard2()
        {
            return new CreditCard()
            {
                Id = 2,
                Number = "9876512",
                CardType = E_CreditCardType.Master
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

        public static Category GetCameraCategory()
        {
            return new Category()
            {
                Id = 1,
                Name = "Camera"
            };
        }

        public static Category GetComputerCategory()
        {
            return new Category()
            {
                Id = 2,
                Name = "Computer"
            };
        }

        public static Category GetPhoneCategory()
        {
            return new Category()
            {
                Id = 3,
                Name = "Phone"
            };
        }

        public static  CustomerOrder GetCustomerOrder1()
        {
            var cart = new ShoppingCart();
            cart.Add(Mother.GetProduct1(), 3);
            cart.Add(Mother.GetProduct2(), 2);

            var buyer = Mother.GetCustomer1();
            var shippingMethod = new StandardShipping();

            return new CustomerOrder(
                cart.Items,
                shippingMethod,
                buyer,
                buyer.CreditCards[0]
            );
        }
    }
}
