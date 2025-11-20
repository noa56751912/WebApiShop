using Entity;

namespace Repository
{
    public interface IRepositoryUser
    {
        User? GetUserById(int id);
        User? Login(ExistingUser existingUser);
        User? Register(User newUser);
        void Update(int id, User updateUser);
    }
}