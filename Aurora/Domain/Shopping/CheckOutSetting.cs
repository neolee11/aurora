using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shopping.Shipping;

namespace Domain.Shopping
{
    public class CheckOutSetting
    {
        public int CreditCardId { get; set; }
        public IShippingMethod ShippingMethod { get; set; }

    }
}
