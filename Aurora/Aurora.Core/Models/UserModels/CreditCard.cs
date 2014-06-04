namespace Aurora.Core.Models.UserModels
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public E_CreditCardType CardType { get; set; }
        public decimal TotalChargedAmount { get; set; }

        public void Charge(decimal amount)
        {
            if (amount > 0)
            {
                TotalChargedAmount += amount;
            }
        }

        public void Refund(decimal amount)
        {
            if (amount > 0)
            {
                TotalChargedAmount -= amount;
            }
        }
    }
}
