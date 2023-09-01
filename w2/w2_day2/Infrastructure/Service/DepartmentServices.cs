using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class DepartmentServices : IBaseService<Department>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Department>> Add(Department c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into department(name)values('{c.Name}')");
                    if (res == 1) return new Response<Department>("Aded department");
                    return new Response<Department>("not found");
                }
            });
        }
        public async Task<List<Department>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Department>($"select name as Name,educationcenterid as EducationCenterId from department").ToList();
                return res;
            }
        }
        public async Task<Response<Department>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select name as Name,educationcenterid as EducationCenterId from department where id={id}").FirstOrDefault();
                    if (res != null) return new Response<Department>("department ", res);
                    return new Response<Department>("not found");
                }
            });
        }
        public async Task<Response<Department>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from department where id ={id}");
                    if (res == 1) return new Response<Department>("department deleted");
                    return new Response<Department>("not found");
                }
            });
        }
        public async Task<Response<Department>> Update(Department c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update department set name ={c.Name},educationcenterid={c.EducationCenterId} where id={c.Id}");
                    if (res == 1) return new Response<Department>("department updated");
                    return new Response<Department>("not found");
                }
            });
        }
    }
}
