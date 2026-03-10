using AutoMapper;
using packstation.Dtos;
using packstation.Entities;
using packstation.Enums;
using packstation.Repositorys;
using System.Data;

namespace packstation.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserResponseDto> CreateUserAsync(UserCreateDto dto)
        {
            

            var user = new User
            {
                UserName = dto.UserName,
                UserLastName = dto.UserLastName,
                Email = dto.Email,
                Role = dto.Role,
                PasswordHash = "test" 
            };


            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangeAsync();

            return _mapper.Map<UserResponseDto>(user);
        }


        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception($"User with ID {id} not found");

            _userRepository.Delete(user);
            await _userRepository.SaveChangeAsync();

            return true;
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null || !users.Any())
                return new List<UserResponseDto>();

            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var users = await _userRepository.GetAllAsync();

            if (users == null || !users.Any())
                return null;

            var user = users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                return null;

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<User> GetUserByEmailForLoginAsync(string email)
        {
            var users = await _userRepository.GetAllAsync();


            return users
                .FirstOrDefault(u =>
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        }


        public async Task<UserResponseDto> UpdateUserAsync(int id, UserUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception($"User with ID {id} not found");

            
            _mapper.Map(dto, user);

            _userRepository.Update(user);
            await _userRepository.SaveChangeAsync();

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
