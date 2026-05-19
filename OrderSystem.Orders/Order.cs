
using System;
using System.Collections.Generic;
using OrderSystem.SharedKernel;

namespace OrderSystem.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{Customer} - RSD {Total}";
        }


    }
}
