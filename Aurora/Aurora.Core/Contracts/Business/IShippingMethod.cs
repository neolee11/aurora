namespace Aurora.Core.Contracts.Business
{
    public interface IShippingMethod
    {
        decimal CalculatePrice();
        string MethodName();
    }
}
