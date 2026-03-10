using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using packstation.Dtos;
using packstation.Services;

namespace packstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var result = await _userService.CreateUserAsync(dto);

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to create user"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.GetAllUsersAsync();

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve users"));
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          try
            {
               var result = await _userService.GetUserByIdAsync(id);

                if (result == null)
                    return NotFound(ApiResponseExtentions.Fail("user not found"));

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve user"));
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
          try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var result = await _userService.UpdateUserAsync(id, dto);

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to update user"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
          try
            {
                var result = await _userService.DeleteUser(id);

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to delete user"));
            }
        }
    }
}
