using System.IO;
using System.Text.Json;
using Entity;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        public readonly UsersContext _context;
        public RepositoryUser(UsersContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Login(ExistingUser existingUser)
        {
           return await _context.Users.FirstOrDefaultAsync(user=>user.Email==existingUser.Email&&user.Password==existingUser.Password);
        }
        public async Task<User> Register(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task Update(int id, User updateUser)
        {
            _context.Users.Update(updateUser);
            await _context.SaveChangesAsync();
           
        }

        public void Delete(int id)
        {
        }

        Task IRepositoryUser.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }


}
