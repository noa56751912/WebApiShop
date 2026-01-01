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

        public async Task<(List<Product> Items, int TotalCount)> GetProducts(int position, int skip, int?[] categoryIds, string description, int? minPrice, int? maxPrice)
        {

            var query = _context.Products.Where(product => (description == null ? (true) : (product.Description.Contains(description)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
            .OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.Skip((position - 1) * skip)
            .Take(skip).Include(product => product.Category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);


        }

    }


}
