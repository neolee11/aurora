using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCard
    {
        public int Id { get; set; }
     
        public string CC_Num { get; set; }
        public CreditCardType CC_Type { get; set; }

        //public int CustomerId { get; set; } //Owner of the credit card
    }
}
