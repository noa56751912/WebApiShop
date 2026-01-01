using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repository;
using TestProject;
using Xunit;

namespace TestProject
{
    public class ProductsRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly ApiShopContext _dbContext;
        private readonly ProductsRepository _repository;

        public ProductsRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _repository = new ProductsRepository(_dbContext);
        }
        [Fact]
        public async Task GetProducts_ShouldFilterSortAndPaginate_WhenParametersAreProvided()
        {
            // Arrange
            // 1. ניקוי המסד
            _dbContext.OrderItems.RemoveRange(_dbContext.OrderItems);
            _dbContext.Products.RemoveRange(_dbContext.Products);
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // 2. יצירת קטגוריות
            var catElec = new Category { CategoryName = "Electronics" };
            var catHome = new Category { CategoryName = "Home" };
            await _dbContext.Categories.AddRangeAsync(catElec, catHome);
            await _dbContext.SaveChangesAsync();

            // 3. יצירת מוצרים עם מחירים ותיאורים שונים
            var prod1 = new Product { ProductName = "Cheap Radio", Price = 50, Description = "Small radio", CategoryId = catElec.CategoryId };
            var prod2 = new Product { ProductName = "Expensive TV", Price = 2000, Description = "Big screen TV", CategoryId = catElec.CategoryId };
            var prod3 = new Product { ProductName = "Gaming Mouse", Price = 100, Description = "Optical mouse", CategoryId = catElec.CategoryId };
            var prod4 = new Product { ProductName = "Sofa", Price = 1500, Description = "Comfy sofa", CategoryId = catHome.CategoryId }; // קטגוריה אחרת

            await _dbContext.Products.AddRangeAsync(prod1, prod2, prod3, prod4);
            await _dbContext.SaveChangesAsync();

            _dbContext.ChangeTracker.Clear();

            // Act
            // אנחנו מחפשים:
            // 1. קטגוריה: רק אלקטרוניקה (מסננים את הספה)
            // 2. מחיר: מינימום 60 (מסננים את הרדיו הזול)
            // 3. מחיר: מקסימום 3000
            // 4. דפדוף: עמוד 1, להביא 10 תוצאות
            int?[] catIds = new int?[] { catElec.CategoryId };

            var result = await _repository.GetProducts(
                position: 1,
                skip: 10,
                categoryIds: catIds,
                description: null,
                maxPrice: 3000,
                minPrice: 60
            );

            // Assert
            // ציפייה: נשארו רק TV ו-Mouse. הרדיו זול מדי, הספה בקטגוריה אחרת.
            Assert.Equal(2, result.TotalCount);
            Assert.Equal(2, result.Items.Count);

            // בדיקת מיון: הפונקציה שלך עושה OrderBy Price
            // לכן Mouse (100) צריך להיות ראשון, ו-TV (2000) שני
            Assert.Equal("Gaming Mouse", result.Items[0].ProductName);
            Assert.Equal("Expensive TV", result.Items[1].ProductName);

            // בדיקת Include: הקטגוריה נטענה
            Assert.NotNull(result.Items[0].Category);
            Assert.Equal("Electronics", result.Items[0].Category.CategoryName);
        }
    }
}