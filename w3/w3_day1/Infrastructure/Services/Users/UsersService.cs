using Dapper;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Context;
namespace Infrastructure.Services.Users;

public class UsersService:IUserService
{
    private readonly DataContext _dataContext;
    public UsersService() => _dataContext = new DataContext();
    public async Task<Response<string>> AddUser(Userss user)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"insert into users(name,email) values('{user.Name}','{user.Email}')";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful added");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<string>> DeleteUser(int id)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"delete from users where id={id}";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful deleted");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<string>> UpdateUser(Userss user)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"update users set name={user.Name},email={user.Email}";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful updated");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<Userss>> GetByIdUser(int id)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"select id as Id, name as Name,email as Email from users where id={id}";
            var res = await con.QueryFirstOrDefaultAsync<Userss>(sql);
            if (res==null) return new Response<Userss>("not found");
            return new Response<Userss>("Successful user found",res);
        }
        catch (Exception e)
        {
            return new Response<Userss>(e.Message);
        }
    }
    public async Task<Response<List<Userss>>> GetUsers()
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"select id as Id, name as Name,email as Email from users";
            var res = await con.QueryAsync<Userss>(sql);
            if (res==null) return new Response<List<Userss>>("not found");
            return new Response<List<Userss>>("Successful users found",res.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Userss>>(e.Message);
        }
    }
}