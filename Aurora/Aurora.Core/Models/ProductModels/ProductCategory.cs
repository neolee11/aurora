namespace Aurora.Core.Models.ProductModels
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductCategory Clone()
        {
            return new ProductCategory() { Id = Id, Name = Name };
        }
    }
}
