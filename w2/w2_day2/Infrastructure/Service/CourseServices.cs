using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class CourseServices : IBaseService<Course>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Course>> Add(Course c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into course(name,educationcenterid)values('{c.CourseName}','{c.EducationCenterId}')");
                    if (res == 1) return new Response<Course>("Aded courses");
                    return new Response<Course>("not found");
                }
            });
        }
        public async Task<List<Course>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Course>($"select  name as CourseName,educationcenterid as EducationCenterId  from course").ToList();
                return res;
                
            }
        }
        public async Task<Response<Course>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select  name as CourseName,educationcenterid as EducationCenterId  from course where id={id}").FirstOrDefault();
                    if (res!= null) return new Response<Course>("courses ", res);
                    return new Response<Course>("not found");
                }
            });
        }
        public async Task<Response<Course>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from course where id ={id}");
                    if (res == 1) return new Response<Course>("course deleted");
                    return new Response<Course>("not found");
                }
            });
        }
        public async Task<Response<Course>> Update(Course c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update course set name ='{c.CourseName}',educationcenterid={c.EducationCenterId} where id={c.Id}");
                    if (res == 1) return new Response<Course>("course updated");
                    return new Response<Course>("not found");
                }
            });
        }
    }
}
