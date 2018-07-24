using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IPriceRule
    {
        bool IsMatch(OrderItemModel item);
        decimal CalculatePrice(OrderItemModel item);
    }
}
