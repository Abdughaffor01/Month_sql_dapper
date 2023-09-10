
using Domain.DTOs.Course;
using Domain.Entities;
using Domain.Wrapper;

namespace Infrastructure.Services.Course
{
    public interface ICourseService
    {
        Task<Response<string>> AddCourse(AddCourseDto addCourse);
        Task<Response<string>> DeleteCourse(int id);
        Task<Response<Courses>> UpdateCourse(Courses courses);
        Task<Response<List<Courses>>> GetCourses();
    }
}
