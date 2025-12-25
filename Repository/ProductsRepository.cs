using System.IO;
using System.Text.Json;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public readonly ApiShopContext _context;
        public ProductsRepository(ApiShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

    }


}
