using ShoppingCart2.Business;
using ShoppingCart2.Enums;

namespace ShoppingCart2.Interfaces
{
    public interface IPriceRuleFactory
    {
        PriceRule Create(PriceRuleType priceRuleType);
    }
}
