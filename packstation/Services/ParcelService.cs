using AutoMapper;
using Microsoft.EntityFrameworkCore;
using packstation.Dtos;
using packstation.Entities;
using packstation.Enums;
using packstation.Repositorys;

namespace packstation.Services
{
    public class ParcelService : IParcelService
    {
        protected readonly IRepository<Parcel> _parcelRepository;
        protected readonly IRepository<ParcelCategory> _categoryRepository;
        private readonly IUserService _userService;
        protected readonly IMapper _mapper;

        public ParcelService(
            IRepository<Parcel> parcelRepository,
            IRepository<ParcelCategory> categoryRepository,
            IUserService userService,
            IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _categoryRepository = categoryRepository;
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<ParcelResponseDto> AddAsync(ParcelCreateDto dto)
        {
            var currentUser = await _userService.GetByEmailAsync(dto.UserEmail)
                ?? throw new Exception("User not found");

            

            var category = await _categoryRepository.GetByIdAsync(dto.ParcelCategoryId)
                ?? throw new Exception("Category not found");

            var parcel = _mapper.Map<Parcel>(dto);

            parcel.UserId = currentUser.Id;
            parcel.ParcelStatus = ParcelStatus.AwaitingForDelivery;

            await _parcelRepository.AddAsync(parcel);
            await _parcelRepository.SaveChangeAsync();

            return _mapper.Map<ParcelResponseDto>(parcel);
        }


        public async Task<ParcelResponseDto> TakeParcelByCustomerAsync(string sendingNumber)
        {
            var parcel = await _parcelRepository.GetBySendingNumberAsync(sendingNumber);

            if (parcel == null)
                throw new Exception("Parcel not found ");

            parcel.ParcelStatus = ParcelStatus.PickedUp;

            _parcelRepository.Update(parcel);
            await _parcelRepository.SaveChangeAsync();

            return _mapper.Map<ParcelResponseDto>(parcel);
        }


        public async Task<List<ParcelResponseDto>> TakeParcelByCourierAsync()
        {
            var parcels = (await _parcelRepository.GetAllAsync())
                .Where(p => p.ParcelStatus == ParcelStatus.AwaitingForDelivery)
                .ToList();

            if (!parcels.Any())
                throw new Exception("No parcels found");

            foreach (var parcel in parcels)
            {
                parcel.ParcelStatus = ParcelStatus.InDelivery;
                _parcelRepository.Update(parcel);
            }

            await _parcelRepository.SaveChangeAsync();

            return _mapper.Map<List<ParcelResponseDto>>(parcels);
        }


        public async Task<List<ParcelResponseDto>> GetAllAsync()
        {
            var parcels = await _parcelRepository.GetAllAsync();
            return _mapper.Map<List<ParcelResponseDto>>(parcels);
        }


        public async Task<ParcelResponseDto> GetByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id)
                ?? throw new Exception("Parcel not found");

            return _mapper.Map<ParcelResponseDto>(parcel);
        }


        public async Task<bool> Delete(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id)
                ?? throw new Exception("Parcel not found");

            _parcelRepository.Delete(parcel);
            await _parcelRepository.SaveChangeAsync();

            return true;
        }


        public async Task<ParcelResponseDto> UpdateAsync(int id, ParcelUpdateDto dto)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
                return null;

            var parcelCategory = await _categoryRepository.GetByIdAsync(dto.ParcelCategoryId);

            if (parcelCategory == null)
                throw new ArgumentException("Category not found", nameof(dto.ParcelCategoryId));

            _mapper.Map(dto, parcel);
            parcel.ParcelCategoryId = parcelCategory.Id;
            parcel.ParcelCategory = parcelCategory;

            _parcelRepository.Update(parcel);
            await _parcelRepository.SaveChangeAsync();

            return _mapper.Map<ParcelResponseDto>(parcel);
        }


        public async Task<List<ParcelResponseDto>> GetByCategory(int categoryId)
        {
            var parcels = await _parcelRepository.Query()
                .Where(c => c.ParcelCategoryId == categoryId)
                .ToListAsync();

            return _mapper.Map<List<ParcelResponseDto>>(parcels);
        }


        public async Task<List<ParcelResponseDto>> GetByStatusAsync(ParcelStatus status)
        {
            var parcels = _parcelRepository.Query()
                .Where(p => p.ParcelStatus == status)
                .ToListAsync();

            return _mapper.Map<List<ParcelResponseDto>>(parcels);
        }


        public async Task<List<ParcelResponseDto>> GetByUserIdAsync(int userId)
        {
            var parcels = await _parcelRepository.Query()
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<ParcelResponseDto>>(parcels);
        }
    }
}