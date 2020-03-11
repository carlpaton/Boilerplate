# ShoppingCart

Simple shopping cart example with pricing rules.

### PricingCalculator

**Interface**: `IPricingCalculator`

`PricingCalculator` expects a list of `IPriceRule` to be injected. It then uses Language-Integrated Query (LINQ) to query the list for `IsMatch` on the passed `OrderItemModel` and then calls `CalculatePrice` which holds the business rules for the price.

### Unit Tests

**Class**: `CartServiceTotalShouldReturn`

This is using MS Test from the namespace `Microsoft.VisualStudio.TestTools.UnitTesting`

Test class naming convention suggested by Steve Smith ~ https://ardalis.com/unit-test-naming-convention

# ShoppingCart2

Another simple shopping cart example with pricing rules, this example uses a factory pattern.

**Interface**: `IPriceRuleFactory`

This returns the base class `PriceRule` which is abstract, there are then specific and concrete price rules that inherit from and implement `PriceRule` using the override keyword. Example `EachPriceRule`

The factory checks the enum `PriceRuleType` and returns the correct concrete price rule.

### Unit Tests

**Class**: `CartServiceTests`

This is using NUnit in the namespace `NUnit.Framework`

The test naming convention followed is UnitOfWork_InitialCondition_ExpectedResult with a AAA pattern of `Arrange`, `Act` and `Assert`.