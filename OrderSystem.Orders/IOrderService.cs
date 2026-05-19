using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.SharedKernel;

namespace OrderSystem.Orders
{public interface IOrderService
    {
        void CreateOrder(string customer, List<OrderItem> items);
        List<Order> GetAllOrders();
    }
}
