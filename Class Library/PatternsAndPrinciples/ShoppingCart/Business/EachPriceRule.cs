using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Business
{
    public class EachPriceRule : IPriceRule
    {
        public bool IsMatch(OrderItemModel item)
        {
            return item.Sku.StartsWith("EACH");
        }

        public decimal CalculatePrice(OrderItemModel item)
        {
            return item.Quantity * 5m;
        }
    }
}
