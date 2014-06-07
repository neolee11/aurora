using System.Collections.Generic;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.TestData
{
    public class CreditCardsMother
    {
        public static List<CreditCard> GetCreditCards()
        {
            var cards = new List<CreditCard> {GetCreditCard1(), GetCreditCard2()};
            return cards;
        }

        public static CreditCard GetCreditCard1()
        {
            return new CreditCard()
            {
                Id = 1,
                Number = "012345",
                CardType = ECreditCardType.Visa,
                TotalChargedAmount = 1000
            };
        }

        public static CreditCard GetCreditCard2()
        {
            return new CreditCard()
            {
                Id = 2,
                Number = "9876512",
                CardType = ECreditCardType.Master,
                TotalChargedAmount = 2000
            };
        } 
    }
}