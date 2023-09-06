using Domein.Model;
using Infrastructure.Services;
using Infrastructure.Services.Generics;

namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class CategoryController: ControllerBase
{
    private readonly CategoryService _categoryService;
    public CategoryController() => _categoryService = new CategoryService();

    [HttpPost("AddCategory")]
    public async Task<Responce<Category>> Add(Category obj) => await _categoryService.Add(obj);
    
    [HttpDelete("DeleteCategory")]
    public async Task<Responce<Category>> Delete(int id) => await _categoryService.Delete(id);
    
    [HttpPut("UpdateCategory")]
    public async Task<Responce<Category>> Update(Category obj) => await _categoryService.Update(obj);

    [HttpGet("GetAllCategory")]
    public async Task<Responce<Category>> GetAll() => await _categoryService.GetAll();
    
    [HttpGet("GetByIdCategory")]
    public async Task<Responce<Category>> GetById(int id) => await _categoryService.GetById(id);
}
