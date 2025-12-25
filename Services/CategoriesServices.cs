
using AutoMapper;
using DTOs;
using Entity;
using Repository;
namespace Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository? _categoriesRepository;
        private IMapper? _mapper;
        public CategoriesServices(ICategoriesRepository? categoriesRepository, IMapper? mapper)
        {
            _categoriesRepository = categoriesRepository;
            mapper = _mapper;
        }
        Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(await _categoriesRepository.GetCategories());
        }

    }
}
