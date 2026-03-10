using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using packstation.Dtos;
using packstation.Enums;
using packstation.Services;

namespace packstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelsController : ControllerBase
    {
        private readonly IParcelService _parcelService;
        private readonly IUserService _userService;

        public ParcelsController(IParcelService parcelService, IUserService userService)
        {
            _parcelService = parcelService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddParcel([FromBody] ParcelCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var createdAt = await _parcelService.AddAsync(dto);

                return Ok(ApiResponseExtentions.Success(createdAt, "parcel added in packstation"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("server error occurred"));
            }
        }

        [HttpPost("takeByCustomer")]
        public async Task<IActionResult> TakeParcelByCustomer(string sendingNumber)
        {
            try
            {
                var result = await _parcelService.TakeParcelByCustomerAsync(sendingNumber);

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to take parcel by customer"));
            }
        }

        [HttpPost("takeyCourier")]
        public async Task<IActionResult> TakeParcelByCourier()
        {
            try
            {
                var result = await _parcelService.TakeParcelByCourierAsync();

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to take parcel by courier"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var parcels = await _parcelService.GetAllAsync();

                return Ok(ApiResponseExtentions.Success(parcels));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve parcels"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var parcel = await _parcelService.GetByIdAsync(id);

                if (parcel == null)
                    return NotFound(ApiResponseExtentions.Fail("parcel not found"));

                return Ok(ApiResponseExtentions.Success(parcel));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve parcel"));
            }
        }

        [HttpGet("filter-by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            try
            {
                var parcels = await _parcelService.GetByCategory(categoryId);

                if (parcels == null)
                    return NotFound(ApiResponseExtentions.Fail("no parcels found for this category"));

                return Ok(ApiResponseExtentions.Success(parcels));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve parcels by category"));
            }
        }

        [HttpGet("filter-by-status/{status}")]
        public async Task<IActionResult> GetByStatus(ParcelStatus status)
        {
            try
            {
                var result = await _parcelService.GetByStatusAsync(status);

                return Ok(ApiResponseExtentions.Success(result));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve parcels by status"));
            }
        }

        [HttpGet("filter-by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var parcel = await _parcelService.GetByUserIdAsync(userId);

                return Ok(ApiResponseExtentions.Success(parcel));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to retrieve parcels by user"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParcel(int id, [FromBody] ParcelUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtentions.Fail("validation error"));

                var updated = await _parcelService.UpdateAsync(id, dto);

                return Ok(ApiResponseExtentions.Success(updated));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("failed to update parcel"));
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcel(int id)
        {
            try
            {
                var deleted = await _parcelService.Delete(id);
                if (!deleted)
                    return NotFound(ApiResponseExtentions.Fail("Item not found or cannot be deleted"));
                return Ok(ApiResponseExtentions.Success(deleted, "item deleted"));

            }
            catch
            {
                return StatusCode(500, ApiResponseExtentions.Fail("Server error occurred"));
            }
        }
    }
}