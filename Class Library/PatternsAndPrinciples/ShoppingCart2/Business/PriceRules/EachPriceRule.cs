using ShoppingCart2.Models;

namespace ShoppingCart2.Business.PriceRules
{
    public class EachPriceRule : PriceRule
    {
        public override decimal CalculatePrice(OrderItemModel item)
        {
            return item.Quantity * 5m;
        }
    }
}
