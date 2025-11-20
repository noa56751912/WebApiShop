using Entity;

namespace Services
{
    public interface IServiceUser
    {
        User? GetUserById(int id);
        User? Login(ExistingUser existingUser);
        User? Register(User newUser);
        bool Update(int id, User updateUser);
    }
}