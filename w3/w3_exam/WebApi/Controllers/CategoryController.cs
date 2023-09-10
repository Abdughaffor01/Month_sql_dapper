using Domain.DTOs.Category;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpPost("AddCategory")]
    public async Task<Response<string>> AddCategory([FromForm] AddCategoryDto addCategoryDto) => await _categoryService.AddCategory(addCategoryDto);

    [HttpPut("UpdateCategory")]
    public async Task<Response<string>> UpdateCategory([FromForm] CategoryDto category) => await _categoryService.UpdateCategory(category);

    [HttpDelete("DeleteCategory")]
    public async Task<Response<string>> DeleteCategory([FromForm] int id) => await _categoryService.DeleteCategory(id);

    [HttpGet("GetCategories")]
    public async Task<Response<List<CategoryDto>>> GetCategories() => await _categoryService.GetCategories();

    [HttpGet("GetCategoryById")]
    public async Task<Response<CategoryDto>> GetCategoryById(int id) => await _categoryService.GetCategoryById(id);

    [HttpGet("GetCategoryByName")]
    public async Task<Response<List<CategoryDto>>> GetCategoryByName(string category) => await _categoryService.GetCategoryByName(category);

}
