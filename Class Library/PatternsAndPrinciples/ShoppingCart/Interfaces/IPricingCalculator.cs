using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    //*** GOOD 
    //IPricingCalculator is small & cohesive. It will be used to calculate the price of an item and nothing else.
    //This follows Interface segregation principle (ISP)
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItemModel item);
    }

    //*** BAD
    public interface IPricingCalculatorBad
    {
        decimal CalculatePrice(OrderItemModel item);

        //This should be in ICustomer
        int CustomerName(int customerId);

        //This could be in something like IOrder
        IEnumerable<int> LastFiveSimliarOrders(int itemId);
    }
}
