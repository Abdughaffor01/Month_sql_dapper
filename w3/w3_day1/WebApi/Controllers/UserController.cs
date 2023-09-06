using Domain.Entities;
using Domain.Response;
using Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase

{
    private readonly UsersService _usersService;
    public UserController() => _usersService = new UsersService();

    [HttpPost("AddUser")]
    public async Task<Response<string>> AddUser(Userss user) => await _usersService.AddUser(user);

    [HttpDelete("DeleteUser")]
    public async Task<Response<string>> DeleteUser(int id) => await _usersService.DeleteUser(id);

    [HttpPut("UpdateUser")]
    public async Task<Response<string>> UpdateUser(Userss user) => await _usersService.UpdateUser(user);

    [HttpGet("GetByIdUser")]
    public async Task<Response<Userss>> GetByIdUser(int id) => await _usersService.GetByIdUser(id);

    [HttpGet("GetUsers")]
    public async Task<Response<List<Userss>>> GetUsers() => await _usersService.GetUsers();

}