
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _ICategoriesServices;
        public CategoriesController(ICategoriesServices categoriesServices)
        {
            _ICategoriesServices = categoriesServices;
        }
    }
}
