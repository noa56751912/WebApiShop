using Entity;
using Entity.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Xunit;

namespace TestProject
{
    public class UserRepositoryUnitTests
    {
        private readonly Mock<ApiShopContext> _mockContext;
        private readonly UserRepository _repository;

        public UserRepositoryUnitTests()
        {
            // יצירת מוק לקונטקסט
            _mockContext = new Mock<ApiShopContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<ApiShopContext>());
            _repository = new UserRepository(_mockContext.Object);
        }

        [Fact]
        public async Task Login_ShouldReturnUser_WhenCredentialsAreCorrect()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Email = "test@gmail.com", Password = "123", FirstName = "Israel" }
            };

            // שימוש ביכולת של Moq.EntityFrameworkCore להחזיר רשימה כ-DbSet
            _mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            // Act
            var result = await _repository.Login("test@gmail.com", "123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Israel", result.FirstName);
        }

        [Fact]
        public async Task GetUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserId = 1, Email = "u1@test.com" },
                new User { UserId = 2, Email = "u2@test.com" }
            };
            _mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            // Act
            var result = await _repository.GetUsers();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Register_ShouldAddUserAndSave()
        {
            // Arrange
            var newUser = new User { Email = "new@test.com", Password = "password" };
            _mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User>());

            // Act
            var result = await _repository.Register(newUser);

            // Assert
            // מוודא שבוצעה קריאה להוספת משתמש וקריאה לשמירה (SaveChangesAsync)
            _mockContext.Verify(m => m.Users.AddAsync(It.IsAny<User>(), default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            Assert.Equal(newUser.Email, result.Email);
        }
    }
}