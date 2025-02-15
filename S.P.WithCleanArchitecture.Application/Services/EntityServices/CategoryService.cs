using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Domain.Exceptions.CategoryExceptions;
using S.P.WithCleanArchitecture.Domain.Interfaces;

namespace S.P.WithCleanArchitecture.Application.Services.EntityServices
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task DeleteCategoryById(int CategoryId)
        {
            if (!await _categoryRepository.DeleteEntityById(CategoryId))
                throw new CategoryNotFoundException($"Category by Id {CategoryId} isn't found");

        }

        public async Task<CategoryDTO> GetCategoryByName(string CategoryName)
        {
           var Category = await _categoryRepository.GetCategoryByName(CategoryName);

            if (Category == null)
                throw new CategoryNotFoundException($"CategoryName {CategoryName} doesn't Exist");

            var CategoryDTO = _mapper.Map<CategoryDTO>(Category);

            return CategoryDTO;
        }
    }
}
