using Dapper;
using Domain.DTOs.Category;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Context;

namespace Infrastructure.Services.Category;
public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;
    public CategoryService(DataContext dataContext) => _dataContext = dataContext;
    public async Task<Response<string>> AddCategory(AddCategoryDto addCategoryDto)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"insert into category(category_name) values('{addCategoryDto.CategoryName}');";
            var res = await con.ExecuteAsync(sql);
            if (res == 0) return new Response<string>("error");
            return new Response<string>("Successful added");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdateCategory(CategoryDto category)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"update category set category_name='{category.CategoryName}' where id={category.Id};";
            var res = await con.ExecuteAsync(sql);
            if (res == 0) return new Response<string>("not found");
            return new Response<string>("Successful updated category");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteCategory(int id)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"delete from category where id={id};";
            var res = await con.ExecuteAsync(sql);
            if (res == 0) return new Response<string>("not found");
            return new Response<string>("Successful deleted");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<List<CategoryDto>>> GetCategories()
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = "select id as Id,category_name as CategoryName from category;";
            var res = await con.QueryAsync<CategoryDto>(sql);
            if (res == null) return new Response<List<CategoryDto>>("not found");
            return new Response<List<CategoryDto>>("Successful founded categories", res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<CategoryDto>>(ex.Message);
        }
    }

    public async Task<Response<CategoryDto>> GetCategoryById(int id)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"select id as Id , category_name as CategoryName from category where id={id};";
            var res = await con.QueryFirstOrDefaultAsync<CategoryDto>(sql);
            if (res == null) return new Response<CategoryDto>("not found");
            return new Response<CategoryDto>("Successful founded category", res);
        }
        catch (Exception ex)
        {
            return new Response<CategoryDto>(ex.Message);
        }
    }

    public async Task<Response<List<CategoryDto>>> GetCategoryByName(string category)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"select id as Id,category_name as CategoryName from category where lower(category_name) like '%{category.ToLower()}%';";
            var res = await con.QueryAsync<CategoryDto>(sql);
            if (res == null) return new Response<List<CategoryDto>>("not found");
            return new Response<List<CategoryDto>>("Successful founded category", res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<CategoryDto>>(ex.Message);
        }
    }

}