using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserInfo
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public E_CreditCardType CardType { get; set; }
        public decimal TotalChargedAmount { get; set; }
        
        /// <summary>
        /// Charge current credit card
        /// </summary>
        /// <param name="amount">Amount less than 0 represents a refund</param>
        public void Charge(decimal amount)
        {
            TotalChargedAmount += amount;
        }
    }
}
