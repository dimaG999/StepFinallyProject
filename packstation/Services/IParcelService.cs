using packstation.Dtos;
using packstation.Enums;

public interface IParcelService
{
    
    Task<ParcelResponseDto> AddAsync(ParcelCreateDto dto);
    Task<ParcelResponseDto> TakeParcelByCustomerAsync(string sendingNumber);
    Task<List<ParcelResponseDto>> TakeParcelByCourierAsync();
    Task<List<ParcelResponseDto>> GetAllAsync();
    Task<ParcelResponseDto> GetByIdAsync(int id);
    Task<List<ParcelResponseDto>> GetByCategory(int categoryId);
    Task<List<ParcelResponseDto>> GetByStatusAsync(ParcelStatus status);
    Task<List<ParcelResponseDto>> GetByUserIdAsync(int userId);
    Task<ParcelResponseDto> UpdateAsync( int id,ParcelUpdateDto dto);
    Task<bool> Delete(int id);

    
   
}
