﻿using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Exceptions;
using Aurora.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Model_Tests.ShoppingCart_Tests
{
    /// <summary>
    /// Summary description for When_Customer_Remove_Products
    /// </summary>
    [TestClass]
    public class When_Customer_Remove_Products
    {
        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Remove_existing_product_should_remove_the_product_from_the_cart()
        {
            var cart = new ShoppingCart();
            var product = ProductMother.GetProduct1();
            cart.Add(product);

            cart.Remove(product.Id);

            Assert.AreEqual(false, cart.Exists(product.Id));
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Remove_product_from_empty_cart_should_make_the_cart_intact()
        {
            var cart = new ShoppingCart();

            cart.Remove(ProductMother.GetProduct1().Id);

            Assert.AreEqual(0, cart.Items.Count);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Remove_non_existing_product_should_make_the_cart_intact()
        {
            var cart = new ShoppingCart();
            var prod1 = ProductMother.GetProduct1();
            cart.Add(prod1, 2);
            var prod2 = ProductMother.GetProduct2();
            cart.Add(prod2, 4);

            cart.Remove(ProductMother.GetProduct3().Id);

            Assert.AreEqual(2, cart.Items.Count);
        }
    }

}
