using System.IO;
using System.Text.Json;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly ApiShopContext _context;
        public UserRepository(ApiShopContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _context.Users.Include(user => user.Orders).FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
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
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }




    }


}
