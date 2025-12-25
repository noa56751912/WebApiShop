
using AutoMapper;
using DTOs;
using Entity;
using Repository;
namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordServices _passwordService;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository repository, IPasswordServices ServicePassword, IMapper mapper)
        {
            _repository = repository;
            _passwordService = ServicePassword;
            _mapper = mapper;
        }
 
        public async Task<UserDTO> GetUserById(int id)
        {
            return _mapper.Map<User, UserDTO>(await _repository.GetUserById(id));
        }

        public async Task<UserDTO> Login(ExistingUserDTO existingUser)
        {
            return _mapper.Map<User, UserDTO>(await _repository.Login(existingUser.Email, existingUser.Password));
        }
        public async Task<UserDTO> Register(UserDTO user)
        {
            int passScore = _passwordService.PasswordStrength(user.Password);
            if (passScore < 2)
                return null;

            User userEntity = _mapper.Map<User>(user);

            return _mapper.Map<UserDTO>(await _repository.Register(userEntity));
        }
        public async Task<bool> Update(int id, UserDTO updateUser)
        {
            int passScore = _passwordService.PasswordStrength(updateUser.Password);
            if (passScore < 2)
                return false;
            User user = _mapper.Map<User>(updateUser);
            await _repository.Update(id, user);
            return true;
        }
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _repository.GetUsers());

        }


    }
}
