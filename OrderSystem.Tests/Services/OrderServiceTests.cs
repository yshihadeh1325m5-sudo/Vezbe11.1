using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OrderSystem.Orders;
using OrderSystem.Pricing;
using OrderSystem.Shared.Application;
using OrderSystem.SharedKernel;

namespace OrderSystem.Tests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_ShouldSaveOrder_AndPublishEvent()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            var eventBusMock = new Mock<IEventBus>();
            var timeMock = new Mock<IDateTimeProvider>();
            var idMock = new Mock<IIdGenerator>();

            idMock.Setup(x => x.NewId()).Returns(Guid.NewGuid());
            timeMock.Setup(x => x.Now()).Returns(new DateTime(2026, 5, 4));

            var pricingService = new PricingService();

            var service = new OrderService(
                repoMock.Object,
                timeMock.Object,
                idMock.Object,
                pricingService,
                eventBusMock.Object
            );

            var items = new List<OrderItem>
            {
                new OrderItem { Product = "Mouse", Price = 20, Quantity = 2 }
            };

            // Act
            service.CreateOrder("Marko", items);

            // Assert
            repoMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
            eventBusMock.Verify(x => x.Publish(It.IsAny<OrderCreatedEvent>()), Times.Once);
        }
    }
}
