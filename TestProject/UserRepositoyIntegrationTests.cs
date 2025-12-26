using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using TestProject;
using Xunit;

namespace TestProject
{
    
    public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly UserRepository _repository;

        public UserRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new UserRepository(_fixture.Context);
        }

        [Fact]
        public async Task Register_And_Then_GetUserById_ShouldWorkInRealDb()
        {
            // Arrange
            var user = new User
            {
                Email = "integration@test.com",
                Password = "secure",
                FirstName = "Integration",
                LastName = "Test"
            };

            // Act
            var registeredUser = await _repository.Register(user);
            var foundUser = await _repository.GetUserById(registeredUser.UserId);

            // Assert
            Assert.NotNull(foundUser);
            Assert.Equal("integration@test.com", foundUser.Email);
        }

        [Fact]
        public async Task Update_ShouldPersistChangesInDb()
        {
            // Arrange
            var user = new User { Email = "update@test.com", Password = "1", FirstName = "Before",  LastName = "Test" };
            await _repository.Register(user);

            // Act
            user.FirstName = "After";
            await _repository.Update(user.UserId, user);

            // Assert
            var updatedUser = await _repository.GetUserById(user.UserId);
            Assert.Equal("After", updatedUser.FirstName);
        }
    }
}