using Entity;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}