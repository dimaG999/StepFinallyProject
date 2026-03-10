using packstation.Dtos;

namespace packstation.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto> GetByIdAsync(int id);
        Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto);
        Task<CategoryResponseDto> UpdateAsync(int id , CategoryUpdateDto dto);
        Task<bool> Delete(int id);
    }
}
