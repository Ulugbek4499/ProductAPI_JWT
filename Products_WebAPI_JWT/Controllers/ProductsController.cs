using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products_Application.DTOs.Products;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Products;

namespace Products_WebAPI_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async ValueTask<IActionResult> PostProductAsync(CreateProductDTO createProductDTO)
        {
            Product product= _mapper.Map<Product>(createProductDTO);

            product.ProductId = Guid.NewGuid();

            await _productService.AddProductAsync(product);

            return Ok(createProductDTO);
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetProductAsync(Guid id)
        {
            Product entity = await _productService.GetProductByIdAsync(id);

            return Ok(entity);
        }

        [HttpGet]
       // [Authorize(Roles = "get_all_products")]
        public IActionResult GetProductAsync()
        {
            IQueryable<Product> entities = _productService.GetAllProducts();

            return Ok(entities);
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutProductAsync(Product product)
        {
            Product entity = await _productService.UpdateProductAsync(product);

            return Ok(entity);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductAsync(Guid id)
        {
            Product entity = await _productService.DeleteProductAsync(id);

            return Ok(entity);
        }
    }
}
