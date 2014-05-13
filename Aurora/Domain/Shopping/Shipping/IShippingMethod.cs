using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public interface IShippingMethod
    {
        decimal CalculatePrice();
    }
}
