using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;

namespace S.P.WithCleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryByName(string CategoryName);
        Task DeleteCategoryById(int CategoryId);
    }

}
