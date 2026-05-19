using OrderSystem.Pricing;
using OrderSystem.Shared.Application;
using OrderSystem.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Orders
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository _repo;

        public OrderQueryService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAll();
        }

        public Order GetOrderById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
