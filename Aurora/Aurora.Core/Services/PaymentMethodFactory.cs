using System;
using Aurora.Core.Contracts.Business;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.Core.Services
{
    public static class PaymentMethodFactory
    {
        //private static IPaymentMethodRepository ;

        public static IPaymentMethod GetPaymentMethod(string paymentName)
        {
            if (string.IsNullOrEmpty(paymentName))
            {
                throw  new Exception("Cannot get payment method. Payment name is empty.");
            }

            var parts = paymentName.Split(new char['-']);
            var method = parts[0].Trim();
            var account = parts[1].Trim();

            E_CreditCardType creditCardType;
            if (E_CreditCardType.TryParse(method, out creditCardType) == true)
            {
                //Lookup credit card
            }
            else
            {
                //look up bank account
            }

            return null;
        }
    }
}