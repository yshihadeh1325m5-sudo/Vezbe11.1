using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Pricing;
using OrderSystem.SharedKernel;

namespace OrderSystem.Tests.Domain
{
    public class PricingServiceTests
    {
        [Fact]
        public void Calculate_WhenItemsExist_ReturnsCorrectTotal()
        {
            // Arrange
            var pricingService = new PricingService();

            var items = new List<OrderItem>
            {
                new OrderItem { Product = "Monitor", Price = 200, Quantity = 2 },
                new OrderItem { Product = "Keyboard", Price = 50, Quantity = 1 }
            };

            // Act
            var total = pricingService.Calculate(items);

            // Assert
            Assert.Equal(450, total);
        }
    }
}
