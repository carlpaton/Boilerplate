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

    // The above can be refactored to use reflection to determine the return typo
    // Doing this makes this class open to extension but closed for modification.
    // The caviet would be your rules would need to:
    // 1. follow the naming convention `PriceRuleType`PriceRule 
    // 2. reside in the same folder Business/PriceRules/

    public class PriceRuleFactoryWithReflection : IPriceRuleFactory
    {
        public PriceRule Create(PriceRuleType priceRuleType)
        {
            try
            {
                return (PriceRule)Activator.CreateInstance(
                    Type.GetType($"ShoppingCart2.Business.PriceRules.{priceRuleType}PriceRule"),
                        new object[] { });
            }
            catch
            {
                return null;
            }
        }
    }
}
