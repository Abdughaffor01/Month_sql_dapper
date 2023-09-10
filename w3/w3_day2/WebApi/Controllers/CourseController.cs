using Domain.DTOs.Course;
using Domain.Wrapper;
using Infrastructure.Services.Course;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)=>_courseService = courseService;
        [HttpPost]
        public async Task<Response<string>> AddCourse([FromForm]AddCourseDto addCourse) => await _courseService.AddCourse(addCourse);

    }
}
