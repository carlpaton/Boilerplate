using ShoppingCart2.Business.PriceRules;
using ShoppingCart2.Enums;
using ShoppingCart2.Interfaces;
using System;

namespace ShoppingCart2.Business
{
    /* Its common for a factory to
     * 
     * 1. take a simple paramter such as a string 'buyTwoGetOneFree', enum just felt neater
     * 2. read some config and return a default 'thing', here the thing is a price rule.
     */

    public class PriceRuleFactory : IPriceRuleFactory
    {
        public PriceRule Create(PriceRuleType priceRuleType)
        {
            switch (priceRuleType)
            {
                case PriceRuleType.Each:
                    return new EachPriceRule();

                default:
                    throw new NotImplementedException($"PriceRule could not be determined by the given priceRuleType: {priceRuleType}");
            }
        }
    }
}
