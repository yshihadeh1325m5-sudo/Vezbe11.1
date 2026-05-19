using OrderSystem.Orders;
using OrderSystem.SharedKernel;
using System.Collections.Generic;

namespace OrderSystem.UI
{
    public class OrderViewModel
    {
        private readonly IOrderQueryService _queryService;
        private readonly IOrderCommandService _commandService;

        private List<OrderItem> _items = new List<OrderItem>();

        public List<Order> Orders { get; private set; } = new List<Order>();

        public OrderViewModel(
            IOrderQueryService queryService,
            IOrderCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;

            Orders = _queryService.GetAllOrders();
        }

        public void AddItem(string product, string priceText, string quantityText)
        {
            var item = new OrderItem
            {
                Product = product,
                Price = decimal.Parse(priceText),
                Quantity = int.Parse(quantityText)
            };

            _items.Add(item);
        }

        public void CreateOrder(string customer)
        {
            _commandService.CreateOrder(customer, _items);

            _items = new List<OrderItem>();
            Orders = _queryService.GetAllOrders();
        }
    }
}