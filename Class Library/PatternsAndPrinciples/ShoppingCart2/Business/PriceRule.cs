using ShoppingCart2.Models;

namespace ShoppingCart2.Business
{
    public abstract class PriceRule
    {
        // Base class members marked with the abstract keyword require that derived classes override them.
        // This means the behaviour will be in the concrete price rule which will have the override keyword.
        public abstract decimal CalculatePrice(OrderItemModel item);
    }
}
