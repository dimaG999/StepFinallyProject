using packstation.Dtos;
using packstation.Entities;
using System.Threading.Tasks;

namespace packstation.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int  id);
        Task<UserResponseDto> CreateUserAsync(UserCreateDto dto);
        Task<UserResponseDto> UpdateUserAsync( int id,UserUpdateDto dto);
        Task<UserResponseDto> GetByEmailAsync(string email);
        Task<User> GetUserByEmailForLoginAsync(string email);
        Task<bool> DeleteUser(int id);
    }
}
