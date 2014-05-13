using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}
