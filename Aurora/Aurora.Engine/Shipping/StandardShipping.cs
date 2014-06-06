using Aurora.Core.Contracts.Business;

namespace Aurora.Engine.Shipping
{
    public class StandardShipping : IShippingMethod
    {
        private decimal _rate = 2.00m;

        public decimal CalculatePrice()
        {
            return _rate;
        }

        public string MethodName()
        {
            return "STANDARD SHIPPING";
        }
    }
}
