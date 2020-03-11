using ShoppingCart2.Enums;

namespace ShoppingCart2.Models
{
    public class OrderItemModel
    {
        /// <summary>
        /// Stock keeping unit
        /// </summary>
        public PriceRuleType Sku { get; set; }
        public int Quantity { get; set; }
    }
}
