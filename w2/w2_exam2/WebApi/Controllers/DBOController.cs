namespace WebApi.Controllers;
using Domein.Model;
using Infrastructure.Services;
using Infrastructure.Services.Generics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DBOController : ControllerBase
{
    private readonly DTOServices _dtoService;
    public DBOController() => _dtoService = new DTOServices();

    [HttpGet("GetStudentByGroup")]
    public async Task<Responce<Student>> GetStudentByGroup(int id) => await _dtoService.GetStudentByGroup(id);

    [HttpGet("GetRandomStudent")]
    public async Task<Responce<Student>> GetRandomStudent() => await _dtoService.GetRandomStudent();

    [HttpGet("GetStudentGroup")]
    public async Task<Responce<DTOStudentWithGroups>> GetStudentGroup() => await _dtoService.GetStudentGroup();

    [HttpGet("GroupsWithStudents")]
    public async Task<Responce<DTOGroupsWithStudents>> GroupsWithStudents() => await _dtoService.GroupsWithStudents();

    [HttpGet("GroupsByIdWithStudents")]
    public async Task<Responce<DTOGroupByIdStudents>> GroupsByIdWithStudents(int id) => await _dtoService.GroupsByIdWithStudents(id);
}