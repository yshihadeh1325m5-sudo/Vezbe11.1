using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Moq;
using OrderSystem.Orders;
using OrderSystem.SharedKernel;
using OrderSystem.UI;

namespace OrderSystem.Tests.ViewModels
{
    public class ViewModelTests
    {
        [Fact]
        public void CreateOrder_ShouldCallCommandService_AndRefreshOrders()
        {
            //Arrange
            var queryMock = new Mock<IOrderQueryService>();
            var commandMock = new Mock<IOrderCommandService>();

            var expectedOrders = new List<Order>()
            {
                new Order
                {
                    Customer = "Ana",
                    Total = 100
                }
            };

            queryMock
                .Setup(q => q.GetAllOrders())
                .Returns(expectedOrders);

            var viewModel = new OrderViewModel(queryMock.Object, commandMock.Object);

            viewModel.AddItem("Tastatura", "50", "2");

            //Act
            viewModel.CreateOrder("Ana");

            //Assert
            commandMock.Verify(x => x.CreateOrder(
                "Ana",
                 It.Is<List<OrderItem>>(_items =>
                 _items.Count == 1 &&
                _items[0].Product == "Tastatura" &&
                _items[0].Price == 50 &&
                _items[0].Quantity == 2)),
                Times.Once);

            Assert.Single(viewModel.Orders);
            Assert.Equal("Ana", viewModel.Orders[0].Customer);
            Assert.Equal(100, viewModel.Orders[0].Total);

        }

        [Fact]
        public void CreateOrder_ShouldRefreshOrders()
        {
            //Arrange
            var queryMock = new Mock<IOrderQueryService>();
            var commandMock = new Mock<IOrderCommandService>();

            var expectedOrders = new List<Order>()
            {
                new Order
                {
                    Customer = "Ana",
                    Total = 100
                }
            };

            queryMock
                .SetupSequence(q => q.GetAllOrders())
                .Returns(new List<Order>())
                .Returns(expectedOrders);

            var viewModel = new OrderViewModel(queryMock.Object, commandMock.Object);

            viewModel.AddItem("Tastatura", "50", "2");

            //Act
            viewModel.CreateOrder("Ana");

            //Assert
            Assert.Single(viewModel.Orders);
            Assert.Equal("Ana", viewModel.Orders[0].Customer);
            Assert.Equal(100, viewModel.Orders[0].Total);

        }

    }
}
