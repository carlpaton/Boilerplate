using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Business.PriceRules
{
    public class WeightPriceRule : IPriceRule
    {
        public bool IsMatch(OrderItemModel item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }

        public decimal CalculatePrice(OrderItemModel item)
        {
            return item.Quantity * 4m / 1000;
        }
    }
}
