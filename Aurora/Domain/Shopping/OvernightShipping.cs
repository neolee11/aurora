using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public class OvernightShipping : IShippingMethod
    {
        private decimal _rate = 10.00m;

        public decimal CalculatePrice()
        {
            return _rate;
        }
    }
}
