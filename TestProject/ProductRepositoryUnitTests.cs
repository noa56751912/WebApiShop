using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Xunit;

namespace TestProject
{
    public class ProductsRepositoryUnitTests
    {
        private readonly Mock<ApiShopContext> _mockContext;
        private readonly ProductsRepository _repository;

        public ProductsRepositoryUnitTests()
        {
            // יצירת מוק לקונטקסט
            _mockContext = new Mock<ApiShopContext>(new DbContextOptions<ApiShopContext>());
            _repository = new ProductsRepository(_mockContext.Object);
        }

        [Fact]
        private ApiShopContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApiShopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApiShopContext(options);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnFilteredResults_AndCorrectTotalCount()
        {
            // Arrange
            var context = GetDbContext();
            context.Products.AddRange(new List<Product>
        {
            new Product { Id = 1, Description = "Apple", Price = 10, CategoryId = 1 },
            new Product { Id = 2, Description = "Banana", Price = 20, CategoryId = 1 },
            new Product { Id = 3, Description = "Carrot", Price = 5, CategoryId = 2 }
        });
            await context.SaveChangesAsync();
            var repository = new ProductRepository(context);

            // Act - Filter for price >= 10 and Category 1
            var result = await repository.GetProducts(1, 10, new int?[] { 1 }, null, 10, null);

            // Assert
            Assert.Equal(2, result.TotalCount);
            Assert.Equal(2, result.Items.Count);
            Assert.All(result.Items, p => Assert.True(p.Price >= 10));
        }

        [Fact]
        public async Task GetProducts_WhenNoMatch_ShouldReturnEmptyListAndZeroCount()
        {
            // Arrange
            var context = GetDbContext(); // Empty DB
            var repository = new ProductRepository(context);

            // Act
            var result = await repository.GetProducts(1, 10, Array.Empty<int?>(), "NonExistent", null, null);

            // Assert
            Assert.Empty(result.Items);
            Assert.Equal(0, result.TotalCount);
        }
    }
}