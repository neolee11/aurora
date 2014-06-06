namespace Aurora.Core.Contracts.Business
{
    public interface IPaymentMethod
    {
        string PaymentName();
        decimal TotalChargedAmount { get; set; }
        bool Charge(decimal amount);
        bool Refund(decimal amount);
    }
}