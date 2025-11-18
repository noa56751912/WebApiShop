
using Entity;
using Repository;
namespace Services
{
    public class ServiceUser : IRepositoryUser, IServiceUser
    {
        private readonly IRepositoryUser _repository;
        private readonly IServicePassword _ServicePassword;

        public ServiceUser(IRepositoryUser repository, IServicePassword ServicePassword)
        {
            _repository = repository;
            _ServicePassword = ServicePassword;
        }

        


        
        public User? GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public User? Login(ExistingUser existingUser)
        {
            return _repository.Login(existingUser);
        }
        public User? Register(User newUser)
        {
            int passScore = _ServicePassword.PasswordStrength(newUser.Password);
            if (passScore < 2)
                return null;
            return _repository.Register(newUser);
        }
        public bool Update(int id, User updateUser)
        {
            int passScore = _ServicePassword.PasswordStrength(updateUser.Password);
            if (passScore < 2)
                return false;
            _repository.Update(id, updateUser);
            return true;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        void IRepositoryUser.Update(int id, User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
