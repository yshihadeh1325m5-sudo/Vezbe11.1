
using System.Collections.Generic;
using System.Linq;
using OrderSystem.SharedKernel;

namespace OrderSystem.Pricing
{
    public class PricingService
    {
        public decimal Calculate(List<OrderItem> items)
        {
            return items.Sum(i => i.Price * i.Quantity);
        }
    }
}
