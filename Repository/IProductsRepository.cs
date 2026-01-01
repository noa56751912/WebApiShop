using Entity;

namespace Repository
{
    public interface IProductsRepository
    {
        public Task<(List<Product> Items, int TotalCount)>GetProducts(int position, int skip, int?[] categoryIds, string description, int? minPrice, int? maxPrice);
    }
}