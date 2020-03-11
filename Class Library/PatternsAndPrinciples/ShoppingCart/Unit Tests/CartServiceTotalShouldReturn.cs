using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Business;
using ShoppingCart.Business.PriceRules;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;

namespace ShoppingCart.Unit_Tests
{
    // Test class naming convention suggested by Steve Smith ~ https://ardalis.com/unit-test-naming-convention
    // This is using the test framework `MS Test`

    [TestClass]
    public class CartServiceTotalShouldReturn
    {
        private CartService _cart;

        //You can also do this in a parameterless constructor: CartTotalShouldReturn()
        [TestInitialize]
        public void Setup()
        {
            var pricingRules = new List<IPriceRule>
            {
                new EachPriceRule(),
                new WeightPriceRule()
            };

            var pricingCalculator = new PricingCalculator(pricingRules);

            _cart = new CartService(pricingCalculator);
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
