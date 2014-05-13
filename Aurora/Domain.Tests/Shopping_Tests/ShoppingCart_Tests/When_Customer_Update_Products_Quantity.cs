using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Shopping;

namespace Domain.Tests.Shopping_Tests.ShoppingCart_Tests
{
    [TestClass]
    public class When_Customer_Update_Products_Quantity
    {
        [TestMethod]
        public void Set_a_product_quantity_to_0_should_remove_this_product_from_cart()
        {
            var cart = new ShoppingCart();
            var product = Mother.GetProduct1();
            cart.Add(product, 2);

            cart.UpdateProductQuantity(product.Id, 0);

            var actualResult = cart.ProductExists(product.Id);
            Assert.AreEqual(false, actualResult);
        }

        [TestMethod]
        public void Set_a_product_quantity_to_a_number_should_make_the_cart_contain_this_number_of_this_product()
        {
            var cart = new ShoppingCart();
            var product = Mother.GetProduct1();
            cart.Add(product);

            var quantity = 4;
            cart.UpdateProductQuantity(product.Id, quantity);

            var actualResult = cart.GetProductQuantity(product.Id);
            Assert.AreEqual(quantity, actualResult);
        }
    }
}
