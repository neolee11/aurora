using Aurora.Core.Models.ShoppingModels;
using Aurora.Core.Models.UserAccountModels;
using Aurora.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Core.Tests.Model_Tests.ShoppingCart_Tests
{
    [TestClass]
    public class When_Customer_Add_Products
    {
        private RegularCustomer _customer;

        [TestInitialize]
        public void SetupTest()
        {
            _customer = Mother.GetCustomer1();
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_1_product_to_empty_cart_should_make_cart_contain_1_product()
        {
            var emptyShoppingCart = new ShoppingCart();
            var product = Mother.GetProduct1();

            emptyShoppingCart.Add(product);

            Assert.AreEqual(1, emptyShoppingCart.Items[0].Quantity);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_product_to_cart_that_already_exist_this_product_should_still_make_this_cart_contain_1_purchase_item()
        {
            var cart = new ShoppingCart();
            var product = Mother.GetProduct1();
            cart.Add(product);

            var product2 = Mother.GetProduct1();
            cart.Add(product2);

            Assert.AreEqual(1, cart.Items.Count);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_product_to_cart_that_does_not_have_this_product_should_make_this_cart_contain_2_purchase_items()
        {
            var cart = new ShoppingCart();
            var product = Mother.GetProduct1();
            cart.Add(product);

            var product2 = Mother.GetProduct2();
            cart.Add(product2);

            Assert.AreEqual(2, cart.Items.Count);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_1_product_to_a_cart_containing_the_same_product_should_increment_the_product_count_by_1()
        {
            var cart = new ShoppingCart();
            cart.Add(Mother.GetProduct1());

            var productSameAsExistingOne = Mother.GetProduct1();
            cart.Add(Mother.GetProduct1());

            var productCount = cart.Items.Find(p => p.Product.Id == productSameAsExistingOne.Id).Quantity;

            Assert.AreEqual(2, productCount);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_product_with_quantity_of_3_should_increment_the_product_count_by_3()
        {
            var cart = new ShoppingCart();
            var productToAdd = Mother.GetProduct1();
            cart.Add(productToAdd, 3);

            var productCount = cart.Items.Find(p => p.Product.Id == productToAdd.Id).Quantity;
            Assert.AreEqual(3, productCount);
        }

        [TestMethod, TestCategory("Core.ShoppingCart")]
        public void Add_product_to_filled_cart_should_increment_the_total_price()
        {
            var cart = new ShoppingCart();
            var existingProduct = Mother.GetProduct1();
            cart.Add(existingProduct);
            cart.Add(existingProduct);

            var newProduct = Mother.GetProduct2();
            cart.Add(newProduct);

            var expectedTotalPrice = existingProduct.RetailPrice * 2 + newProduct.RetailPrice;

            Assert.AreEqual(expectedTotalPrice, cart.GetTotalPrice());
        }

        [ClassCleanup]
        public static void TearDown()
        {

        }

    }
}
