using System.IO;
using OrderSystem.Orders;
using OrderSystem.Persistence.Infrastructure;
using OrderSystem.SharedKernel;

namespace OrderSystem.Tests.Infrastructure
{
    public class JsonOrderRepositoryTests
    {
        [Fact]
        [Trait("Category", "Integration")]
        public void Add_ShouldSaveOrderToJsonFile()
        {
            var filePath = Path.GetTempPath();
            var repository = new JsonOrderRepository();

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Customer = "Ana",
                Total = 100,
                Created = DateTime.Now,
                Items = new List<OrderItem>() 

            };

            repository.Add(order);

            var orders = repository.GetAll();

            Assert.Single (orders);
            Assert.Equal (100, orders[0].Total);
            Assert.Equal("Ana", orders[0].Customer);

        }
    }
}