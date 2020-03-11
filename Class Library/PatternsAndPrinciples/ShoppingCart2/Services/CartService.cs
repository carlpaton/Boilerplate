using ShoppingCart2.Interfaces;
using ShoppingCart2.Models;
using System.Collections.Generic;

namespace ShoppingCart2.Services
{
    public class CartService
    {
        private readonly List<OrderItemModel> _items;
        private readonly IPriceRuleFactory _priceRuleFactory;

        public CartService(IPriceRuleFactory priceRuleFactory) 
        {
            _priceRuleFactory = priceRuleFactory;
            _items = new List<OrderItemModel>();
        }

        public IEnumerable<OrderItemModel> SelectList
        {
            get { return _items; }
        }

        public void Insert(OrderItemModel item)
        {
            _items.Add(item);
        }

        public decimal SumOfCost()
        {
            decimal total = 0m;
            foreach (var item in SelectList)
            {
                var priceRule = _priceRuleFactory.Create(item.Sku);
                total += priceRule.CalculatePrice(item);
            }
            return total;
        }
    }
}
