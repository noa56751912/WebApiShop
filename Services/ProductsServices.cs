
using AutoMapper;
using DTOs;
using Entity;
using Repository;

namespace Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _repository;
        public readonly IMapper _mapper;
        public ProductsServices(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _repository.GetProducts());
        }
    }
}
