using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Orders
{
    public interface IOrderQueryService
    {
        List<Order> GetAllOrders();
    }
}
