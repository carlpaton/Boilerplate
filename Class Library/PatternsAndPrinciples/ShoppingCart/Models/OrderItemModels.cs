namespace ShoppingCart.Models
{
    public class OrderItemModel
    {
        /// <summary>
        /// Stock keeping unit
        /// </summary>
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }
}
