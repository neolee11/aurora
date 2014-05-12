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
        private List<PurchaseItem> _items;
        public List<PurchaseItem> Items
        {
            get
            {
                return _items;
            }
        }

        public ShoppingCart()
        {
            _items = new List<PurchaseItem>();
        }

        public void Add(Product product)
        {
            var thisProductInCart = _items.Where(p => p.Product.Id == product.Id).SingleOrDefault();

            if (thisProductInCart == null)
            {
                var purchaseItem = new PurchaseItem()
                {
                    Product = product,
                    Quantity = 1
                };

                _items.Add(purchaseItem);
            }
            else
            {
                thisProductInCart.Quantity++;
            }

        }

        public void Add(Product product, int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                Add(product);
            }
        }
    }
}
