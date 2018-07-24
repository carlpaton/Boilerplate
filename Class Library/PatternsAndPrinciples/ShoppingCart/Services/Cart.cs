using ShoppingCart.Business;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Services
{
    public class Cart
    {
        private readonly List<OrderItemModel> _items;
        private readonly IPricingCalculator _pricingCalculator;

        //Inversion of control (IOC) would normally be passed to this classes constructor using Dependancy Injection (DI)
        //For this example its hard coded as this Class Library has no startup routine.
        public Cart() : this(new PricingCalculator())
        {
        }

        public Cart(IPricingCalculator pricingCalculator)
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

        //*** GOOD
        //SumOfCost is open for extension, but closed for modification.
        //This follows Open/Closed Principle (OCP)
        public decimal SumOfCost()
        {
            decimal total = 0m;
            foreach (var item in SelectList)
            {
                total += _pricingCalculator.CalculatePrice(item);
            }
            return total;
        }

        //*** BAD
        public decimal SumOfCostBad()
        {
            decimal total = 0m;
            foreach (var item in SelectList)
            {
                //As business rules grow or change this condition will need to be modified.
                //This is a code smell 

                if (item.Sku.StartsWith("EACH"))
                    total += item.Quantity * 5m;
                else if (item.Sku.StartsWith("WEIGHT"))
                    total += item.Quantity * 4m / 1000;

                //other such as SPECIALS
            }
            return total;
        }
    }
}
