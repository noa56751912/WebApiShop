using Entity;
using DTOs;
namespace Repository
{
    public interface IUserRepository
    {
        
        Task<User> GetUserById(int id);
        Task<User> Login(string user, string password);
        Task<User> Register(User newUser);

        Task Update(int id,User newUser);
        Task<IEnumerable<User>> GetUsers();
    }
}