using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// This is a tempoary type for current user selected items. It's not saved into database
    /// </summary>
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}
