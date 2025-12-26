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
        public async Task GetProducts_ShouldReturnAllProductsFromContext()
        {
            // Arrange - הכנת נתונים פיקטיביים
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", Price = 3000 },
                new Product { ProductId = 2, ProductName = "Mouse", Price = 150 },
                new Product { ProductId = 3, ProductName = "Keyboard", Price = 250 }
            };

            // הגדרת המוק שיחזיר את הרשימה הזו כשפונים ל-Products
            _mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            // Act - הרצת הפונקציה
            var result = await _repository.GetProducts();

            // Assert - בדיקה שהתוצאה נכונה
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Contains(result, p => p.ProductName == "Laptop");
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            // Arrange - רשימה ריקה
            _mockContext.Setup(x => x.Products).ReturnsDbSet(new List<Product>());

            // Act
            var result = await _repository.GetProducts();

            // Assert
            Assert.Empty(result);
        }
    }
}