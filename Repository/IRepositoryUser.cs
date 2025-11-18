using Entity;

namespace Repository
{
    public interface IRepositoryUser
    {
        void Delete(int id);
        User? GetUserById(int id);
        User? Login(ExistingUser existingUser);
        User? Register(User newUser);
        void Update(int id, User updateUser);
    }
}