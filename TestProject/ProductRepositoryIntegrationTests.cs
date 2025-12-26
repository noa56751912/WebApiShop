using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using TestProject;
using Xunit;

namespace TestProject
{
    public class ProductsRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly ProductsRepository _repository;

        public ProductsRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new ProductsRepository(_fixture.Context);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnProductsFromRealDatabase()
        {
            // Arrange - ניקוי והכנת דאטה אמיתי בבסיס הנתונים של הטסטים
            _fixture.Context.Products.RemoveRange(_fixture.Context.Products);
            var category = new Category { CategoryName = "Electronics" };
            await _fixture.Context.Categories.AddAsync(category);
            await _fixture.Context.SaveChangesAsync();
            

            var testProduct = new Product
            {
                ProductName = "Real DB Product",
                Price = 99,
                Description = "Testing integration",
                CategoryId = 1 // וודא שיש קטגוריה עם ID 1 או צור אחת ב-Fixture
            };

            await _fixture.Context.Products.AddAsync(testProduct);
            await _fixture.Context.SaveChangesAsync();

            // Act
            var result = await _repository.GetProducts();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, p => p.ProductName == "Real DB Product");
        }
    }
}