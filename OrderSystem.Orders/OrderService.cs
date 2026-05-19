
using OrderSystem.Notifications.Application;
using OrderSystem.Shared.Application;
using OrderSystem.SharedKernel;
using OrderSystem.Pricing;
using System.Collections.Generic;
using System;

namespace OrderSystem.Orders
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IDateTimeProvider _time;
        private readonly IIdGenerator _id;
        private readonly PricingService _pricing;
        private readonly IEventBus _eventBus;

        public OrderService(
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
