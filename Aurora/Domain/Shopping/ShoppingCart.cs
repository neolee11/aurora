using Domain.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shopping
{
    /// <summary>
    /// </summary>
    public class ShoppingCart
    {
        #region Properties
        private List<PurchaseItem> _items;
        public List<PurchaseItem> Items
        {
            get
            {
                return _items;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in _items)
                {
                    total += item.Product.Price * item.Quantity;
                }
                return total;
            }
        }
        #endregion

        public ShoppingCart()
        {
            _items = new List<PurchaseItem>();
        }

        #region Add
        public void Add(Product product)
        {
            var thisProductInCart = _items.SingleOrDefault(p => p.Product.Id == product.Id);

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
            for (var i = 0; i < quantity; i++)
            {
                Add(product);

            }
        }
        #endregion



        #region Remove
        public void Remove(int productId)
        {
            if (ProductExists(productId) == false)
                return;

            _items.Remove(_items.Where(i => i.Product.Id == productId).Single());
        }

        #endregion

        #region Update
        public void UpdateProductQuantity(int productId, int quantity)
        {
            if (ProductExists(productId) == false || quantity < 0)
                return;

            var productItem = _items.Where(i => i.Product.Id == productId).Single();

            if (quantity == 0)
                Remove(productId);
            else
                productItem.Quantity = quantity;
        }
        #endregion

        #region Information
        public bool ProductExists(int productId)
        {
            return _items.Exists(p => p.Product.Id == productId);
        }

        public int GetProductQuantity(int productId)
        {
            if (ProductExists(productId) == false)
                return 0;

            return _items.Where(i => i.Product.Id == productId).Single().Quantity;
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
        #endregion



    }
}
