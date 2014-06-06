using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.ShoppingModels
{
    public class CheckOutSetting
    {
        public int CreditCardId { get; set; }
        public IShippingMethod ShippingMethod { get; set; }

    }
}
