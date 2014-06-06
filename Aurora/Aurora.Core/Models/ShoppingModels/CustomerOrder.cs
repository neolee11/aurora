using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.ShoppingModels
{
    public class CustomerOrder
    {
        //Order ID
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }

        public List<PurchaseItem> Items { get; set; }
        public CustomerBase Customer { get; set; }
        public EOrderStatus Status { get; set; }

        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }

        public decimal ProductCost { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }

        public CustomerOrder()
        {
            Items = new List<PurchaseItem>();
        }

    }
}
