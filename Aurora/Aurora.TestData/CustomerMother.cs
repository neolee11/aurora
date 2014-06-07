using System;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.TestData
{
    public class CustomerMother
    {
        public static RegularCustomer GetCustomer1()
        {
            return new RegularCustomer
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Li",
                Username = "tomli",
                DateJoined = new DateTime(2014, 5, 1),
                IsStudent = true,
                ShippingAddress = AddressMother.GetAddress1(),
                CreditCards = CreditCardsMother.GetCreditCards()
            };
        }
    }
}