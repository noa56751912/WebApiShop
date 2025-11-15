using System.IO;
using System.Text.Json;
using Entity;
using Repository;
namespace Services
{
    public class ServiceUser
    {
        RepositoryUser repository = new RepositoryUser();
        public User? GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User? Login(ExistingUser existingUser)
        {
            return repository.Login(existingUser);
        }
        public User? Register(User newUser)
        {
            return repository.Register(newUser);
        }
        public void Update(int id, User updateUser)
        {
            repository.Update(id, updateUser);
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
