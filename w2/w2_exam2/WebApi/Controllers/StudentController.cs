namespace WebApi.Controllers;
using Domein.Model;
using Infrastructure.Services;
using Infrastructure.Services.Generics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController:ControllerBase
{
    private readonly StudentService _studentService;
    public StudentController() => _studentService = new StudentService();

    [HttpGet("GetAllStudent")]
    public async Task<Responce<List<Student>>> GetAll() => await _studentService.GetAll();
    
    [HttpGet("GetByIdStudent")]
    public async Task<Responce<Student>> GetById(int id) => await _studentService.GetById(id);
    
    [HttpPost("AddStudent")]
    public async Task<Responce<Student>> Add(Student obj) => await _studentService.Add(obj);
    
    [HttpPut("UpdateStudent")]
    public async Task<Responce<Student>> Update(Student obj) => await _studentService.Update(obj);
    
    [HttpDelete("DeleteStudent")]
    public async Task<Responce<Student>> Delete(int id) => await _studentService.Delete(id);
}