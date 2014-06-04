using Aurora.Core.Models.ProductModels;

namespace Aurora.Core.Models.ShoppingModels
{
    public class PurchaseItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public PurchaseItem Clone()
        {
            return new PurchaseItem()
            {
                Product = this.Product.Clone(),
                Quantity = Quantity
            };
        }
    }
}
