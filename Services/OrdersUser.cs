
using Entity;
using Repository;
namespace Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repository;
        private readonly IServicePassword _ServicePassword;

        public ServiceUser(IRepositoryUser repository, IServicePassword ServicePassword)
        {
            _repository = repository;
            _ServicePassword = ServicePassword;
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
            int passScore = _ServicePassword.PasswordStrength(newUser.Password);
            if (passScore < 2)
                return null;
            return await _repository.Register(newUser);
            
        }
        public async Task<bool> Update(int id, User updateUser)
        {
            int passScore = _ServicePassword.PasswordStrength(updateUser.Password);
            if (passScore < 2)
                return false;
            await _repository.Update(id, updateUser);
            return true;
        }
        

    }
}
