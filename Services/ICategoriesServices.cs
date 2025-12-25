using Entity;
using DTOs;
using AutoMapper;

namespace Services
{
    public interface ICategoriesServices
    {

        Task<IEnumerable<CategoryDTO>> GetCategories();
    }
}