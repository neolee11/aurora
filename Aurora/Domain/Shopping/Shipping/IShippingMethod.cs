namespace Domain.Shopping.Shipping
{
    public interface IShippingMethod
    {
        decimal CalculatePrice();
    }
}
