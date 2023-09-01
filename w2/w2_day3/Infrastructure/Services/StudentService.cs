using Dapper;
using Domein.Model;
using Infrastructure.Services.Generic;
using Npgsql;
namespace Infrastructure.Services
{
    public class StudentService:IbaseService<Student>
    {
        string cons = "Server=localhost;Port=5432;Database=students;User Id=postgres;Password=987849660;";
        public async Task<Response<Student>> GetAll()
        {
            return await Task.Run(() =>
            {
                using (var con = new NpgsqlConnection(cons))
                {
                    var res = con.Query<Student>("select id as Id, firstname as FirstName,lastname as LastName,age as Age,email as Email from student").ToList();
                    if (res == null) return new Response<Student>("not found");
                    return new Response<Student>("Students", res);
                }
            });
        }
        public async Task<Response<Student>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var con = new NpgsqlConnection(cons))
                {
                    var res = con.QueryFirstOrDefault<Student>($"select firstname as FirstName,lastname as LastName,age as Age,email as Email from student where id={id}");
                    if (res == null) return new Response<Student>("not found");
                    return new Response<Student>("Students", res);
                }
            });
        }
        public async Task<Response<Student>> Add(Student entity)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (var con = new NpgsqlConnection(cons))
                    {
                        var res = con.Execute($"insert into student(firstname,lastname,age,email) values('{entity.FirstName}','{entity.LastName}','{entity.Age}','{entity.Email}') ");
                        if (res == 0) return new Response<Student>("error");
                        return new Response<Student>("Successful added student");
                    }
                });
            }
            catch (Exception)
            {

                return new Response<Student>("email already exists");
            }
        }
        public async Task<Response<Student>> Update(Student entity)
        {
            return await Task.Run(() =>
            {
                using (var con = new NpgsqlConnection(cons))
                {
                    var res = con.Execute($"update student set firstname='{entity.FirstName}',lastname='{entity.LastName}',age={entity.Age},email='{entity.Email}' where id={entity.Id}");
                    if (res == 0) return new Response<Student>("error not student");
                    return new Response<Student>("Successful updated student");
                }
            });
        }
        public async Task<Response<Student>> Delete(int id)
        {
            return await Task.Run(() =>
            {
                using (var con = new NpgsqlConnection(cons))
                {
                    var res = con.Execute($"delete from student where id={id}");
                    if (res == 0) return new Response<Student>("error not student");
                    return new Response<Student>("Successful deleted student");
                }
            });
        }
    }
}
