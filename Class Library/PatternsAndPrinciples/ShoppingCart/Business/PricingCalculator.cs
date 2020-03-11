using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Business
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> _pricingRules;

        public PricingCalculator(List<IPriceRule> pricingRules)
        {
            _pricingRules = pricingRules;
        }

        public decimal CalculatePrice(OrderItemModel item)
        {
            return _pricingRules
                .First(r => r.IsMatch(item))
                .CalculatePrice(item);
        }
    }
}
