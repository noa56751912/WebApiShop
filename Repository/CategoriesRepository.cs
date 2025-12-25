using System.IO;
using System.Text.Json;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {

        public readonly ApiShopContext _context;
        public CategoriesRepository(ApiShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }


}
