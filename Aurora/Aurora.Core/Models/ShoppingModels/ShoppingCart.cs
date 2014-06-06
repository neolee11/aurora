using System.Collections.Generic;
using System.Linq;
using Aurora.Core.Models.ProductModels;
using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.ShoppingModels
{
    /// <summary>
    /// </summary>
    public class ShoppingCart : IPurchaseItemList
    {
        #region Properties
        public List<PurchaseItem> Items { get; set; }
        #endregion

        #region Constructor

        public ShoppingCart()
        {
            Items = new List<PurchaseItem>();
        }

        #endregion

        #region Add
        public void Add(InventoryProduct product)
        {
            var thisProductInCart = Items.SingleOrDefault(p => p.Product.Id == product.Id);

            if (thisProductInCart == null)
            {
                var purchaseItem = new PurchaseItem()
                {
                    Product = product,
                    Quantity = 1
                };

                Items.Add(purchaseItem);
            }
            else
            {
                thisProductInCart.Quantity++;
            }
        }

        public void Add(InventoryProduct product, int quantity)
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
            if (Exists(productId) == false)
                return;

            Items.Remove(Items.Single(i => i.Product.Id == productId));
        }
        #endregion

        #region Update
        public void UpdateProductQuantity(int productId, int quantity)
        {
            if (Exists(productId) == false || quantity < 0)
                return;

            var productItem = Items.Single(i => i.Product.Id == productId);

            if (quantity == 0)
                Remove(productId);
            else
                productItem.Quantity = quantity;
        }
        #endregion

        #region Information
        public decimal GetTotalPrice()
        {
            return Items.Sum(item => item.Product.RetailPrice * item.Quantity);
        }

        public int GetProductQuantity(int productId)
        {
             if (Exists(productId) == false)
                 return 0;

             return Items.Single(i => i.Product.Id == productId).Quantity;
        }

        public bool Exists(int productId)
        {
            return Items.Exists(p => p.Product.Id == productId);
        }

        public bool IsEmpty()
        {
            return Items.Count == 0;
        }
        #endregion
    }
}
