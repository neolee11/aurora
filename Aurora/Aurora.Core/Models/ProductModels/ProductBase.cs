namespace Aurora.Core.Models.ProductModels
{
    public abstract class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public decimal VendorPrice { get; set; }
    }
}