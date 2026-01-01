
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
        public async Task<PageResponseDTO<ProductDTO>> GetProducts(int position, int skip, int?[] categoryIds, string description, int? minPrice, int? maxPrice)
        {
            ( List<Product>, int) items=await _repository.GetProducts(position, skip, categoryIds, description, minPrice, maxPrice);
            List<ProductDTO> item=_mapper.Map<List<Product>, List<ProductDTO>>(items.Item1);
            PageResponseDTO<ProductDTO> pageResponse = new();
            pageResponse.Data = item;
            pageResponse.TotalItems = items.Item2;
            pageResponse.CurrentPage = position;
            pageResponse.PageSize = skip;
            pageResponse.HasPreviousPage = (position > 1);
            
            int sumPages = pageResponse.TotalItems / pageResponse.PageSize;
            if (pageResponse.TotalItems % pageResponse.PageSize != 0)
                sumPages += 1;
            pageResponse.HasNextPage = (pageResponse.CurrentPage < sumPages);
            return pageResponse;
           // return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _repository.GetProducts());
        }
    }
}
