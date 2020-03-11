# ShoppingCart

Simple shopping cart example with pricing rules.

### PricingCalculator

**Interface**: `IPricingCalculator`

`PricingCalculator` expects a list of `IPriceRule` to be injected. It then uses Language-Integrated Query (LINQ) to query the list for `IsMatch` on the passed `OrderItemModel` and then calls `CalculatePrice` which holds the business rules for the price.

