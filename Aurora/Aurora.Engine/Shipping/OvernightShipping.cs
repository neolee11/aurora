using Aurora.Core.Contracts.Shopping;

namespace Aurora.Engine.Shipping
{
    public class OvernightShipping : IShippingMethod
    {
        private const decimal Rate = 10.00m;

        public decimal CalculatePrice()
        {
            return Rate;
        }
    }
}
