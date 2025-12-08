using Entity;

namespace Services
{
    public interface IProductsUser
    {
      
        Task<User> GetUserById(int id);
        Task<User> Login(ExistingUser existingUser);
        Task<User> Register(User newUser);
        Task<bool> Update(int id, User updateUser);
    }
}