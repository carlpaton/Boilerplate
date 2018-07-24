using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Business
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> _pricingRules;

        public PricingCalculator()
        {
            //Although this class is not closed to modification, new classes are simply added here that match a new price rule
            //The new classes can then be tested without worrying about regression on existing classes

            _pricingRules = new List<IPriceRule>
            {
                new EachPriceRule(),
                new WeightPriceRule()
            };
        }

        public decimal CalculatePrice(OrderItemModel item)
        {
            return _pricingRules.First(r => r.IsMatch(item)).CalculatePrice(item);
        }
    }
}
