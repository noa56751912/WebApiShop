using Entity;

namespace Repository
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}