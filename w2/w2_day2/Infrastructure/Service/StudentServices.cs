using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class StudentServices : IBaseService<Student>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Student>> Add(Student c)
        {
            return await Task.Run(async () =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into student(firstname,lastname,age,gender,address,idgroup,startdategroup,enddategroup) values('{c.FirstName}','{c.LastName}','{c.Age}','{c.Gender}','{c.Address}','{c.IdGroup}','{c.StartDateGroup}','{c.EndDateGroup}')");
                    if (res == 1) return new Response<Student>("Aded student");
                    return new Response<Student>("not found");
                }
            });
        }
        public async Task<List<Student>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Student>($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,idgroup as IdGroup,startdategroup as StartDateGroup,enddategroup as EndDateGroup from student").ToList();
                return res;
            }
        }
        public async Task<Response<Student>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,idgroup as IdGroup,startdategroup as StartDateGroup,enddategroup as EndDateGroup from student where id={id}").FirstOrDefault();
                    if (res != null) return new Response<Student>("student ", res);
                    return new Response<Student>("not found");
                }
            });
        }
        public async Task<Response<Student>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from student where id ={id}");
                    if (res == 1) return new Response<Student>("student deleted");
                    return new Response<Student>("not found");
                }
            });
        }
        public async Task<Response<Student>> Update(Student c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update student set firstname={c.FirstName},lastname={c.LastName},age={c.Age},gender={c.Gender},address={c.Address},idgroup={c.IdGroup},startdategroup={c.StartDateGroup},enddategroup={c.EndDateGroup} where id={c.Id}");
                    if (res == 1) return new Response<Student>("student updated");
                    return new Response<Student>("not found");
                }
            });
        }
    }
}
