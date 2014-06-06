using Aurora.Core.Models.ProductModels;

namespace Aurora.Core.Contracts.Business
{
    public abstract class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public decimal VendorPrice { get; set; }
    }
}