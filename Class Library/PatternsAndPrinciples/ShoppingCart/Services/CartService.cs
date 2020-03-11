using ShoppingCart.Business;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Services
{
    public class CartService
    {
        private readonly List<OrderItemModel> _items;
        private readonly IPricingCalculator _pricingCalculator;

        public CartService(IPricingCalculator pricingCalculator)
        {
            _pricingCalculator = pricingCalculator;
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

        // *** GOOD
        // SumOfCost is open for extension, but closed for modification.
        // This follows Open/Closed Principle (OCP)
        public decimal SumOfCost()
        {
            decimal total = 0m;
            foreach (var item in SelectList)
            {
                total += _pricingCalculator.CalculatePrice(item);
            }
            return total;
        }

        // *** BAD
        public decimal SumOfCostBad()
        {
            decimal total = 0m;
            foreach (var item in SelectList)
            {
                // As business rules grow or change this condition will need to be modified.
                // This is a code smell 

                if (item.Sku.StartsWith("EACH"))
                    total += item.Quantity * 5m;
                else if (item.Sku.StartsWith("WEIGHT"))
                    total += item.Quantity * 4m / 1000;

                // others such as SPECIALS
            }
            return total;
        }
    }
}
