using System;
using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.ProductModels
{
    public class InventoryProduct : ProductBase
    {
        public decimal RetailPrice { get; set; }

        public InventoryProduct Clone()
        {
            return new InventoryProduct()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Category = this.Category.Clone(),
                Vendor = Vendor,
                VendorPrice = VendorPrice,
                RetailPrice = RetailPrice
            };
        }
    }
    
}
