using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public enum E_OrderStatus
    {
        Unknown = 0, //unknown state
        Processing, //order in processing state
        Shipped, //order shipped to customer
        Cancelled //order cancelled by customer before shipping
    }
}
