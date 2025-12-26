using Entity;
using Repository;
using TestProject;
using Xunit;

namespace TestProject
{
    public class CategoriesRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly CategoriesRepository _repository;

        public CategoriesRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new CategoriesRepository(_fixture.Context);
        }

        [Fact]
        public async Task GetCategories_ShouldReturnDataFromRealDb()
        {
            // Arrange - ניקוי והכנסת נתונים אמיתיים לטבלת הטסטים
            _fixture.Context.Categories.RemoveRange(_fixture.Context.Categories);

            var testCategory = new Category { CategoryName = "Home Decor" };
            await _fixture.Context.Categories.AddAsync(testCategory);
            await _fixture.Context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, c => c.CategoryName == "Home Decor");
        }
    }
}