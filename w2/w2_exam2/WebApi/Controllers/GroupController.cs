using Domein.Model;
using Infrastructure.Services;
using Infrastructure.Services.Generics;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class GroupController:ControllerBase
{
    private readonly GroupService _groupService;
    public GroupController() => _groupService = new GroupService();

    [HttpGet("GetAllGroup")]
    public async Task<Responce<Groups>> GetAll()=> await _groupService.GetAll();
    
    [HttpGet("GetByIdGroup")]
    public async Task<Responce<Groups>> GetById(int id)=> await _groupService.GetById(id);
    
    [HttpPost("AddGroup")]
    public async Task<Responce<Groups>> Add(Groups obj) => await _groupService.Add(obj);

    [HttpPut("UpdateGroup")]
    public async Task<Responce<Groups>> Update(Groups obj) => await _groupService.Update(obj);

    [HttpDelete("DeleteGroup")]
    public async Task<Responce<Groups>> Delete(int id) => await _groupService.Delete(id);
}