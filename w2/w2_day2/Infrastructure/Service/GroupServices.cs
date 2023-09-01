using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class GroupServices : IBaseService<Group>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Group>> Add(Group c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into groups(name,courseid,teacherid)values('{c.GroupName}','{c.CourseId}','{c.TeacherId}')");
                    if (res == 1) return new Response<Group>("Aded group");
                    return new Response<Group>("not found");
                }
            });
        }
        public async Task<List<Group>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Group>($"select name as GroupName,courseid as CourseId,teacherid as TeacherId from groups").ToList();
                return res;
            }
        }
        public async Task<Response<Group>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select name as GroupName,courseid as CourseId,teacherid as TeacherId from groups where id={id}").FirstOrDefault();
                    if (res != null) return new Response<Group>("groups ", res);
                    return new Response<Group>("not found");
                }
            });
        }
        public async Task<Response<Group>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from groups where id ={id}");
                    if (res == 1) return new Response<Group>("groups deleted");
                    return new Response<Group>("not found");
                }
            });
        }
        public async Task<Response<Group>> Update(Group c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update groups set name ={c.GroupName},courseid={c.CourseId},tacherid={c.TeacherId} where id={c.Id}");
                    if (res == 1) return new Response<Group>("groups updated");
                    return new Response<Group>("not found");
                }
            });
        }
    }
}
