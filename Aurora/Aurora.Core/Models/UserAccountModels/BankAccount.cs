using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.UserAccountModels
{
    public class BankAccount : IPaymentMethod
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public decimal TotalChargedAmount { get; set; }

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

        public string PaymentName()
        {
            return string.Format("{0} - {1}", BankName, AccountNumber);
        }
    }
}