using Aurora.Core.Models.ProductModels;

namespace Aurora.TestData
{
    public class ProductCategoryMother
    {
        public static ProductCategory GetCameraCategory()
        {
            return new ProductCategory()
            {
                Id = 1,
                Name = "Camera"
            };
        }

        public static ProductCategory GetComputerCategory()
        {
            return new ProductCategory()
            {
                Id = 2,
                Name = "Computer"
            };
        }

        public static ProductCategory GetPhoneCategory()
        {
            return new ProductCategory()
            {
                Id = 3,
                Name = "Phone"
            };
        } 
    }
}