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
    public class OrderCommandService :IOrderCommandService
    {
        private readonly IOrderRepository _repo;
        private readonly IDateTimeProvider _time;
        private readonly IIdGenerator _id;
        private readonly PricingService _pricing;
        private readonly IEventBus _eventBus;

        public OrderCommandService(
            IOrderRepository repo,
            IDateTimeProvider time,
            IIdGenerator id,
            PricingService pricing,
            IEventBus eventBus)
        {
            _repo = repo;
            _time = time;
            _id = id;
            _pricing = pricing;
            _eventBus = eventBus;
        }

        public void CreateOrder(string customer, List<OrderItem> items)
        {
            var total = _pricing.Calculate(items);

            var order = new Order
            {
                Id = _id.NewId(),
                Customer = customer,
                Items = items,
                Total = total,
                Created = _time.Now()
            };

            _repo.Add(order);
            //_notification.Send(customer, "Order created");
            _eventBus.Publish(new OrderCreatedEvent
            {
                Custumer = customer,
                Total = total
            });
        }
    }
}
