using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shipping
{
    public interface IShippingMethod
    {
        decimal CalculatePrice();
    }
}
