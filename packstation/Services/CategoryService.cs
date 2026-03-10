using AutoMapper;
using packstation.Dtos;
using packstation.Entities;
using packstation.Repositorys;

namespace packstation.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly IRepository<ParcelCategory> _categoryRepository;
        protected readonly IMapper _mapper;

        public CategoryService(IRepository<ParcelCategory> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var category = _mapper.Map<ParcelCategory>(dto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangeAsync();

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception($"Category with ID {id} not found");

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangeAsync();

            return true;
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (categories == null || !categories.Any())
                return new List<CategoryResponseDto>();

            return _mapper.Map<List<CategoryResponseDto>>(categories);
        }

        public async Task<CategoryResponseDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return null;

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<CategoryResponseDto> UpdateAsync(int id, CategoryUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception($"Category with ID {id} not found");

            _mapper.Map(dto, category);
            await _categoryRepository.SaveChangeAsync();

            return _mapper.Map<CategoryResponseDto>(category);
        }
    }
}
