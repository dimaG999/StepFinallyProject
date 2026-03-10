using AutoMapper;
using packstation.Dtos;
using packstation.Entities;

namespace packstation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserResponseDto>();
        }

    }
}
