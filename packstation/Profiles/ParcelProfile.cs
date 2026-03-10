using AutoMapper;
using packstation.Dtos;
using packstation.Entities;

namespace packstation.Profiles
{
    public class ParcelProfile : Profile
    {
        public ParcelProfile() {

            CreateMap<ParcelCreateDto, Parcel>();
            CreateMap<ParcelUpdateDto, Parcel>();
            CreateMap<Parcel, ParcelResponseDto>();
        }
    }
}
