using Domain.Response;
using Domain.Entities;
namespace Infrastructure.Services.Users;
public interface IUserService
{
    Task<Response<string>> AddUser(Userss user);
    Task<Response<string>> DeleteUser(int id);
    Task<Response<string>> UpdateUser(Userss user);
    Task<Response<Userss>> GetByIdUser(int id);
    Task<Response<List<Userss>>> GetUsers();
}