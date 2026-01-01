using Entity;
using DTOs;
namespace Services
{
    public interface IProductsServices
    {

        public Task<PageResponseDTO<ProductDTO>> GetProducts(int position, int skip, int?[] categoryIds, string description, int? minPrice, int? maxPrice);
    }
}