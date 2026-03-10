using AutoMapper;
using packstation.Dtos;
using packstation.Entities;

namespace packstation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<CategoryCreateDto, ParcelCategory>();
            CreateMap<CategoryUpdateDto, ParcelCategory>();
            CreateMap<ParcelCategory, CategoryResponseDto>();
        }
    }
}
