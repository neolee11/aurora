using Aurora.Core.Models.UserAccountModels;

namespace Aurora.TestData
{
    public class AddressMother
    {
        public static Address GetAddress1()
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
    }
}