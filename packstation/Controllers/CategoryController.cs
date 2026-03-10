using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using packstation.Dtos;
using packstation.Services;

namespace packstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var category = await _categoryService.CreateAsync(dto);

                return Ok(ApiResponseExtentions.Success(category));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to create category"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();

                return Ok(ApiResponseExtentions.Success(categories));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve categories"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                if (category == null)
                    return NotFound(ApiResponseExtentions.Fail("category not found"));

                return Ok(ApiResponseExtentions.Success(category));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve category"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var updated = await _categoryService.UpdateAsync(id, dto);

                return Ok(ApiResponseExtentions.Success(updated));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to update category"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _categoryService.Delete(id);
                if (!deleted)
                    return NotFound(ApiResponseExtentions.Fail("did not found"));

                return Ok(ApiResponseExtentions.Success(null,"item deleted"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to delete category"));
            }
        }
    }
}