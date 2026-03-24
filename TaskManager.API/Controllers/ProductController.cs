using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Services;
using TaskManager.Domain.constants;
using TaskManager.Infrastructure.Persistence;

namespace TaskManager.API.Controllers
{
    
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductResponseDTO>>> GetProdcts([FromQuery] PaginationParams p)
        {

            var result = await _productService.GetAllAsync(p);


            return Ok(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> CreateProduct([FromForm]CreateProductDTO dto)
        {
            var product = await _productService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetProdcts),
                new { id = product.Name },
                product);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                                    "wwwroot/images",
                                    fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var url = $"{Request.Scheme}://{Request.Host}/images/{fileName}";

            return Ok(new { imageUrl = url });
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllNoPagination()
        {
            var products = await _productService.GetAllNoPaginationAsync();

            return Ok(products);
        }
        [AllowAnonymous]
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetByCategory(Guid categoryId)
        {
            var products = await _productService.GetByCategoryAsync(categoryId);

            return Ok(products);
        }




        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
