using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.API.Controllers
{

    [Route("api/Category")]
    [ApiController]
    


        public class CategoriesController : ControllerBase
        {
            private readonly ICategoryServices _service;

            public CategoriesController(ICategoryServices service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetCategories()
            {
                var categories = await _service.GetAllAsync();

                return Ok(categories);
            }

            [HttpPost]
            public async Task<ActionResult<CategoryResponseDTO>> CreateCategory(CreateCategoryDTO dto)
            {
                var category = await _service.CreateAsync(dto);

                return Ok(category);
            }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _service.GetByIdAsync(id);

            if (category == null)
                return NotFound("Category not found");

            return Ok(category);
        }
    }
    
}
