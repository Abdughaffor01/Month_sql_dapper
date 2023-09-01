using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class EducationCenterServices : IBaseService<EducationCenter>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<EducationCenter>> Add(EducationCenter c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into educationcenter(name)values('{c.Name}')");
                    if (res == 1) return new Response<EducationCenter>("Aded educationcenter");
                    return new Response<EducationCenter>("not found");
                }
            });
        }
        public async Task<List<EducationCenter>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<EducationCenter>($"select name as Name from educationcenter").ToList();
                return res;
            }
        }
        public async Task<Response<EducationCenter>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select name as Name from educationcenter where id={id}").FirstOrDefault();
                    if (res != null) return new Response<EducationCenter>("Educationcenter ", res);
                    return new Response<EducationCenter>("not found");
                }
            });
        }
        public async Task<Response<EducationCenter>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from educationcenter where id ={id}");
                    if (res == 1) return new Response<EducationCenter>("educationcenter deleted");
                    return new Response<EducationCenter>("not found");
                }
            });
        }
        public async Task<Response<EducationCenter>> Update(EducationCenter c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update educationcenter set name ={c.Name} where id={c.Id}");
                    if (res == 1) return new Response<EducationCenter>("educationcenter updated");
                    return new Response<EducationCenter>("not found");
                }
            });
        }
    }
}