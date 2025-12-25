using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Models;
using Repository;

namespace TestProject
{
    public class UserRepositoyIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly ApiShopContext _dbContext;
        private readonly UserRepository _userRepository;
        public UserRepositoyIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _userRepository = new UserRepository(_dbContext);
        }

        [Fact]
        public async Task Register_ShouldAddUserToDatabase_WhenUserIsValid()
        {
            // Arrange
            _dbContext.Users.RemoveRange(_dbContext.Users);
            await _dbContext.SaveChangesAsync();
            var userToAdd = new User
            {
                Email = "newUser@gmail.com",
                FirstName = "Test",
                LastName = "User",
                Password = "SecurePassword123"
            };

            // Act
            var result = await _userRepository.Register(userToAdd);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.UserId);
            Assert.Equal("New", result.FirstName);

            var userInDb = await _dbContext.Users.FindAsync(result.UserId);
            Assert.NotNull(userInDb);
            Assert.Equal("newUser@gmail.com", userInDb.Email);
        }
    }
}
}
