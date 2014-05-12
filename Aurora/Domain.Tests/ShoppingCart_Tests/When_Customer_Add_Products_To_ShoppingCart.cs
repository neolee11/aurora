using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests.ShoppingCart_Tests
{
    [TestClass]
    public class When_Customer_Add_Products_To_ShoppingCart
    {
        private Customer _customer;

        [TestInitialize]
        public void SetupTest()
        {
            _customer = Mother.Get1Customer();
        }

        //[ExpectedException]
        //[DeploymentItem("")]
        //[DataSource()]
        public void Then()
        {
        }

        [TestMethod]
        public void Add_1_product_to_empty_cart_should_make_cart_contain_1_product()
        {
            var emptyShoppingCart = new ShoppingCart();
            var product = Mother.Get1Product();

            emptyShoppingCart.Add(product);

            Assert.AreEqual(1, emptyShoppingCart.Items[0].Quantity);
        }

        [TestMethod]
        public void Add_product_to_cart_that_already_exist_this_product_should_still_make_this_cart_contain_1_purchase_item()
        {
            var cart = new ShoppingCart();
            var product = Mother.Get1Product();
            cart.Add(product);

            var product2 = Mother.Get1Product();
            cart.Add(product2);

            Assert.AreEqual(1, cart.Items.Count);
        }

        [TestMethod]
        public void Add_product_to_cart_that_does_not_have_this_product_should_make_this_cart_contain_2_purchase_items()
        {
            var cart = new ShoppingCart();
            var product = Mother.Get1Product();
            cart.Add(product);

            var product2 = Mother.Get2ndProduct();
            cart.Add(product2);

            Assert.AreEqual(2, cart.Items.Count);
        }

        [TestMethod]
        public void Add_1_product_to_a_cart_containing_the_same_product_should_increment_the_product_count_by_1()
        {
            var cart = new ShoppingCart();
            cart.Add(Mother.Get1Product());

            var productSameAsExistingOne = Mother.Get1Product();
            cart.Add(Mother.Get1Product());

            var productCount = cart.Items.Find(p => p.Product.Id == productSameAsExistingOne.Id).Quantity;

            Assert.AreEqual(2, productCount);
            //StringAssert.
            //CollectionAssert
        }

        [TestMethod]
        public void Add_product_with_quantity_of_3_should_increment_the_product_count_by_3()
        {
            var cart = new ShoppingCart();
            var productToAdd = Mother.Get1Product();
            cart.Add(productToAdd, 3);

            var productCount = cart.Items.Find(p => p.Product.Id == productToAdd.Id).Quantity;
            Assert.AreEqual(3, productCount);
        }



        [ClassCleanup]
        public static void TearDown()
        {

        }

    }
}
