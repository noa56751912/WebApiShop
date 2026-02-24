using DTOs;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        [HttpGet]
        public async Task<ActionResult<PageResponseDTO<ProductDTO>>> Get(int position, int skip, [FromQuery] int?[] categoryIds, string? description, int? maxPrice, int? minPrice)
        {
            PageResponseDTO<ProductDTO> pageResponse = await _productsServices.GetProducts(position, skip, categoryIds, description, maxPrice, minPrice);
            if (pageResponse.Data.Count() > 0)
                return Ok(pageResponse);
            return NoContent();
        }
    }
}