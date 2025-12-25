using Entity;
using Entity.Models;
using Moq;
using Repository;
using Moq.EntityFrameworkCore;

namespace TestProject
{
    public class UserRepositoryUnitTesting
    {
            [Fact]
            public async Task Register_ShouldAddUserToDatabase_WhenUserIsValid()
            {
                // Arrange
                var mockContext = new Mock<ApiShopContext>();
                mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User>());

                var repository = new UserRepository(mockContext.Object);

                var newUser = new User
                {
                    Email = "avraham@example.co.il",
                    FirstName = "Avraham",
                    LastName = "Fried",
                    Password = "StrongPassword!2025"
                };

                // Act
                var result = await repository.Register(newUser);

                // Assert
                Assert.NotNull(result);

                Assert.Equal("Avraham", result.FirstName);
                Assert.Equal("avraham@example.co.il", result.Email);

                mockContext.Verify(x => x.Users.AddAsync(It.IsAny<User>(), default), Times.Once);
                mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
            }
        }
    }

