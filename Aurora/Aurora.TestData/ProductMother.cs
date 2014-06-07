using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Models.ProductModels;

namespace Aurora.TestData
{
    public class ProductMother
    {
        public static InventoryProduct GetProduct1()
        {
            return new InventoryProduct()
            {
                Id = 1,
                Name = "Sony A7",
                Category = ProductCategoryMother.GetCameraCategory(),
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
                Category = ProductCategoryMother.GetComputerCategory(),
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
                Category = ProductCategoryMother.GetComputerCategory(),
                Description = "Cisco IP Phone",
                RetailPrice = 95.00m
            };
        }
    }
}
