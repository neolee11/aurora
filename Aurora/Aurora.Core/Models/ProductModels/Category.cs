namespace Aurora.Core.Models.ProductModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category Clone()
        {
            return new Category() { Id = Id, Name = Name };
        }
    }
}
