using System;

namespace Aurora.Core.Models.ProductModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Decimal Price { get; set; }

        public Product Clone()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Category = this.Category.Clone(),
                Price = Price
            };
        }
    }
}
