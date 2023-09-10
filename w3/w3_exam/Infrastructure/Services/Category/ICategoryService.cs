using Domain.DTOs.Category;
using Domain.Entities;
using Domain.Response;
namespace Infrastructure.Services;
public interface ICategoryService
{
    Task<Response<string>> AddCategory(AddCategoryDto addCategoryDto);
    Task<Response<string>> DeleteCategory(int id);
    Task<Response<string>> UpdateCategory(CategoryDto category);
    Task<Response<CategoryDto>> GetCategoryById(int id);
    Task<Response<List<CategoryDto>>> GetCategoryByName(string category);
    Task<Response<List<CategoryDto>>> GetCategories();
}
