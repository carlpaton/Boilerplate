using NUnit.Framework;
using ShoppingCart2.Business;
using ShoppingCart2.Interfaces;
using ShoppingCart2.Models;
using ShoppingCart2.Services;

namespace ShoppingCart2.Unit_Tests
{
    // Follows another popular unit test naming strategy where the test class is called `ClassUnderTest` with `Tests` suffixed to the end.
    // I am neither an advocate for or against any of these naming strategys, I think its important to understand there are different ways to name things and to rather follow what your organisation has adopted as the standard.

    // Uses the testing framework `NUnit`

    [TestFixture]
    public class CartServiceTests
    {
        private IPriceRuleFactory _priceRuleFactory;

        [SetUp]
        public void SetUp()
        {
            _priceRuleFactory = new PriceRuleFactory();
        }

        [Test]
        public void SumOfCost_with_one_each_item_returns_five()
        {
            // Arrange
            var expected = 5;
            var classUnderTest = new CartService(_priceRuleFactory);
            classUnderTest.Insert(new OrderItemModel() { Quantity = 1, Sku =  Enums.PriceRuleType.Each });

            // Act
            var actual = classUnderTest.SumOfCost();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
