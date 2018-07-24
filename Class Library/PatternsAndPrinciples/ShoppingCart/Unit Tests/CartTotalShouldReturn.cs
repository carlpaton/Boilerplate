using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Unit_Tests
{
    //Test class naming convention suggested by Steve Smith ~ https://ardalis.com/unit-test-naming-convention

    [TestClass]
    public class CartTotalShouldReturn
    {
        private Cart _cart;

        //You can also do this in a parameterless constructor: CartTotalShouldReturn()
        [TestInitialize]
        public void Setup()
        {
            _cart = new Cart();
        }

        [TestMethod]
        public void FiveWithOneEachItem()
        {
            _cart.Insert(new OrderItemModel() { Quantity = 1, Sku = "EACH_BANANA" });
            Assert.AreEqual(5.0m, _cart.SumOfCost());
        }

        [TestMethod]
        public void TwoWithHalfKiloWeightItem()
        {
            _cart.Insert(new OrderItemModel() { Quantity = 500, Sku = "WEIGHT_APPLE" });
            Assert.AreEqual(2m, _cart.SumOfCost());
        }
    }
}
