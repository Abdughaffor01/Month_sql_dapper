using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class TeacherServices : IBaseService<Teacher>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Teacher>> Add(Teacher c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into teacher(firstname,lastname,age,gender,address,salary,experience) values('{c.FirstName}','{c.LastName}','{c.Age}','{c.Gender}','{c.Address}','{c.Salary}','{c.Experience}')");
                    if (res == 1) return new Response<Teacher>("Aded teacher");
                    return new Response<Teacher>("not found");
                }
            });
        }
        public async Task<List<Teacher>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Teacher>($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,salary as Salary,experience as Experience from teacher").ToList();
                return res;
            }
        }
        public async Task<Response<Teacher>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,salary as Salary,experience as Experience from teacher where id={id}").FirstOrDefault();
                    if (res != null) return new Response<Teacher>("teacher ", res);
                    return new Response<Teacher>("not found");
                }
            });
        }
        public async Task<Response<Teacher>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from teacher where id ={id}");
                    if (res == 1) return new Response<Teacher>("teacher deleted");
                    return new Response<Teacher>("not found");
                }
            });
        }
        public async Task<Response<Teacher>> Update(Teacher c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update teacher set firstname={c.FirstName},lastname={c.LastName},age={c.Age},gender={c.Gender},address={c.Address},salary={c.Salary},experience={c.Experience} where id={c.Id}");
                    if (res == 1) return new Response<Teacher>("teacher updated");
                    return new Response<Teacher>("not found");
                }
            });
        }
    }
}
