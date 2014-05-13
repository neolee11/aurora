using Domain.ProductDomain;
using Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public static class Mother
    {
        public static Customer Get1Customer()
        {
            return new Customer
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Li",
                Username = "tomli",
                DateJoined = new DateTime(2014, 5, 1),
                IsMarried = true,
                ShippingAddress = Get1Address()
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

        public static Product GetProduct1()
        {
            return new Product()
            {
                Id = 1,
                Name = "Sony A7",
                Category = GetCameraCategory(),
                Description = "Mirrorless Compact Digital Camera",
                Price = 1599.99m
            };
        }

        public static Product GetProduct2()
        {
            return new Product()
            {
                Id = 2,
                Name = "Lenovo Y400",
                Category = GetComputerCategory(),
                Description = "Lenovo Laptop Computer",
                Price = 899.99m
            };
        }

        public static Product GetProduct3()
        {
            return new Product()
            {
                Id = 3,
                Name = "Cisco Phone 7945",
                Category = GetComputerCategory(),
                Description = "Cisco IP Phone",
                Price = 95.00m
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
    }
}
