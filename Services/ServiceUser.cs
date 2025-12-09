
using Entity;
using Repository;
namespace Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repository;
        private readonly IServicePassword _servicePassword;

        public ServiceUser(IRepositoryUser repository, IServicePassword servicePassword)
        {
            _repository = repository;
            _servicePassword = servicePassword;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }

        public async Task<User> Login(ExistingUser existingUser)
        {
            return await _repository.Login(existingUser);
        }
        public async Task<User> Register(User newUser)
        {
            int passScore = _servicePassword.PasswordStrength(newUser.Password);
            if (passScore < 2)
                return null;
            return await _repository.Register(newUser);
            
        }
        public async Task<bool> Update(int id, User updateUser)
        {
            int passScore = _servicePassword.PasswordStrength(updateUser.Password);
            if (passScore < 2)
                return false;
            await _repository.Update(id, updateUser);
            return true;
        }
        

    }
}
