using Entity;
using Repository;
using TestProject;
using Xunit;

namespace TestProject
{
    public class OrdersRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly OrdersRepository _repository;

        public OrdersRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new OrdersRepository(_fixture.Context);
        }

        [Fact]
        public async Task AddOrder_ShouldPersistInRealDatabase()
        {
            
            
            _fixture.Context.Orders.RemoveRange(_fixture.Context.Orders);

            
            var user = new User { FirstName = "Order", LastName = "User", Email = "order@test.com", Password = "1" };
            await _fixture.Context.Users.AddAsync(user);
            await _fixture.Context.SaveChangesAsync(); // שמירה כדי לקבל UserId
            var order = new Order
            {
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderSum = 250
                // הערה: אם יש Constraints ב-DB, תצטרך להוסיף UserId קיים
            };

            // Act
            var savedOrder = await _repository.AddOrder(order);

            // Assert
            var orderFromDb = await _fixture.Context.Orders.FindAsync(savedOrder.OrderId);
            Assert.NotNull(orderFromDb);
            Assert.Equal(250, orderFromDb.OrderSum);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturnNull_WhenOrderDoesNotExist()
        {
            // Act
            var result = await _repository.GetOrderById(9999); // ID שלא קיים

            // Assert
            Assert.Null(result);
        }
    }
}
