using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public class CheckOutSetting
    {
        public int CreditCardId { get; set; }
        public IShippingMethod ShippingMethod { get; set; }

    }
}
