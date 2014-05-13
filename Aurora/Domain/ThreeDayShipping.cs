using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ThreeDayShipping : IShippingMethod
    {
        private decimal _rate = 5.00m;

        public decimal CalculatePrice()
        {
            return _rate;
        }
    }
}
