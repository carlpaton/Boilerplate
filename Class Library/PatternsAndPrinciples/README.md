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

### PriceRuleFactory

**Interface**: `IPriceRuleFactory`

This returns the base class `PriceRule` which is abstract, there are then specific and concrete price rules that inherit from and implement `PriceRule` using the override keyword. Example `EachPriceRule`

The factory checks the enum `PriceRuleType` and returns the correct concrete price rule.

### Unit Tests

**Class**: `CartServiceTests`

The test naming convention followed is UnitOfWork_InitialCondition_ExpectedResult with a AAA pattern of `Arrange`, `Act` and `Assert`.

### Reflection 

The factory in `ShoppingCart2` can use reflection instead of the switch statement, so `PriceRule Create` would just have:

```c#
public PriceRule Create(PriceRuleType priceRuleType)
{
	try
	{
		return (PriceRule)Activator.CreateInstance(
		Type.GetType($"ShoppingCart2.Business.PriceRules.{priceRuleType}PriceRule"));
	}
	catch
	{
		return null;
	}
}
```

If the price rule's constructor took parameters you could just include `new object[] { foo, bar }`

```c#
(PriceRule)Activator.CreateInstance(
Type.GetType($"ShoppingCart2.Business.PriceRules.{priceRuleType}PriceRule"),
new object[] { foo, bar });
```

Doing this makes this class open to extension but closed for modification. The caveat would be your rules would need to:

* follow the naming convention `PriceRuleType`PriceRule
* reside in the same folder Business/PriceRules/