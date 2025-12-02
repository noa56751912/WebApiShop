using Entity;

namespace Repository
{
    public interface IRepositoryUser
    {
        Task Delete(int id);
        Task<User> GetUserById(int id);
        Task<User> Login(ExistingUser existingUser);
        Task<User> Register(User newUser);
        Task Update(int id, User updateUser);
    }
}