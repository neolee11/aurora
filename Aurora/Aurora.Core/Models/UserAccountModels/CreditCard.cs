using Aurora.Core.Contracts.Business;
namespace Aurora.Core.Models.UserAccountModels
{
    public class CreditCard : IPaymentMethod
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ECreditCardType CardType { get; set; }
        public decimal TotalChargedAmount { get; set; }

        public string PaymentName()
        {
            return string.Format("{0} - {1}", CardType.ToString(), Number);
        }

        public bool Charge(decimal amount)
        {
            if (amount >= 0)
            {
                TotalChargedAmount += amount;
                return true;
            }
            return false;
        }

        public bool Refund(decimal amount)
        {
            if (amount >= 0)
            {
                TotalChargedAmount -= amount;
                return true;
            }
            return false;
        }
    }
}
