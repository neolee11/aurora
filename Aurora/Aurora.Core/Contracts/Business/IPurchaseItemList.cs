using System.Collections;
using System.Collections.Generic;
using Aurora.Core.Models.ProductModels;
using Aurora.Core.Models.ShoppingModels;

namespace Aurora.Core.Contracts.Business
{
    public interface IPurchaseItemList
    {
        List<PurchaseItem> Items { get; set; }

        void Add(InventoryProduct product);
        void Add(InventoryProduct product, int quantity);
        void Remove(int productId);
        void UpdateProductQuantity(int productId, int quantity);

        decimal GetTotalPrice();
        int GetProductQuantity(int productId);
        bool Exists(int productId);
        bool IsEmpty();
    }
}