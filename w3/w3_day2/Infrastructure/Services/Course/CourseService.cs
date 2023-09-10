using Dapper;
using Domain.DTOs.Course;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using System;
namespace Infrastructure.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _dataContext;
        public CourseService(DataContext dataContext)=>_dataContext = dataContext;
        public async Task<Response<string>> AddCourse(AddCourseDto addCourse)
        {
            try
            {
                using var conn=_dataContext.CreateConnection();
                string sql = $"insert into course(coursename,coursedescription,fee,duration,startdate,enddate,studentlimit)" +
                    $"values(@CourseName,@CourseDescription,@Fee,Duration,StartDate,EndDate,@StudentLimit)";
                var res = await conn.ExecuteAsync(sql, addCourse);
                if (res==1) return new Response<string>("Added");
                return new Response<string>("");
            }
            catch (Exception ex)
            {
                return new Response<string>($"{ex}");
            }
        }

        public Task<Response<string>> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Courses>>> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Courses>> UpdateCourse(Courses courses)
        {
            throw new NotImplementedException();
        }
    }
}
