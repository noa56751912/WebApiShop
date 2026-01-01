using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Xunit;

namespace TestProject
{
    public class OrdersRepositoryUnitTests
    {
        private readonly Mock<ApiShopContext> _mockContext;
        private readonly OrdersRepository _repository;

        public OrdersRepositoryUnitTests()
        {
            _mockContext = new Mock<ApiShopContext>(new DbContextOptions<ApiShopContext>());
            _repository = new OrdersRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddOrder_ShouldSaveOrderAndReturnIt()
        {
            // Arrange
            var newOrder = new Order { OrderDate = DateOnly.FromDateTime(DateTime.Now), OrderSum = 100, UserId = 1 };
            _mockContext.Setup(x => x.Orders).ReturnsDbSet(new List<Order>());

            // Act
            var result = await _repository.AddOrder(newOrder);

            // Assert
            _mockContext.Verify(m => m.Orders.AddAsync(It.IsAny<Order>(), default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            Assert.Equal(newOrder.OrderSum, result.OrderSum);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturnCorrectOrder()
        {
            // Arrange
            var orderId = 10;
            var order = new Order { OrderId = orderId, OrderSum = 500 };

            // ב-FindAsync של Moq.EntityFrameworkCore משתמשים ב-Setup של ה-DbSet
            _mockContext.Setup(x => x.Orders.FindAsync(orderId)).ReturnsAsync(order);

            // Act
            var result = await _repository.GetOrderById(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.OrderId);
        }
    }
}