using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Xunit;

namespace TestProject
{
    public class CategoriesRepositoryUnitTests
    {
        private readonly Mock<ApiShopContext> _mockContext;
        private readonly CategoriesRepository _repository;

        public CategoriesRepositoryUnitTests()
        {
            // יצירת Mock לקונטקסט
            _mockContext = new Mock<ApiShopContext>(new DbContextOptions<ApiShopContext>());
            _repository = new CategoriesRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetCategories_ShouldReturnAllCategories()
        {
            // Arrange - הכנת נתונים מדומים
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Clothing" }
            };

            // הגדרת המוק שיחזיר את הרשימה
            _mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, c => c.CategoryName == "Electronics");
        }

        [Fact]
        public async Task GetCategories_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            _mockContext.Setup(x => x.Categories).ReturnsDbSet(new List<Category>());

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.Empty(result);
        }
    }
}