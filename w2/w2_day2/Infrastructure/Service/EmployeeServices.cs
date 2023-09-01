using Dapper;
using Domein.Model;
using Infrastructure.Service.Generics;
using Npgsql;
namespace Infrastructure.Service
{
    public class EmployeeServices : IBaseService<Employee>
    {
        string con = "Server=localhost;Port=5432;Database=Softclub;User Id=postgres;Password=987849660";
        public async Task<Response<Employee>> Add(Employee c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"insert into employee(firstname,lastname,age,gender,address,departmentid,position) values('{c.FirstName}','{c.LastName}','{c.Age}','{c.Gender}','{c.Address}','{c.DepartmentId}','{c.Position}')");
                    if (res == 1) return new Response<Employee>("Aded employee");
                    return new Response<Employee>("not found");
                }
            });
        }
        public async Task<List<Employee>> GetAll()
        {
            await using (var conn = new NpgsqlConnection(con))
            {
                var res = conn.Query<Employee>($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,departmentid as DepartmentId,position as Position from employee").ToList();
                return res;
            }
        }
        public async Task<Response<Employee>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Query($"select firstname as FirstName,lastname as LastName,age as Age,gender as Gender,address as Address,departmentid as DepartmentId,position as Position from employee where id={id}").FirstOrDefault();
                    if (res != null) return new Response<Employee>("employee ", res);
                    return new Response<Employee>("not found");
                }
            });
        }
        public async Task<Response<Employee>> Remove(int id)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"delete from employee where id ={id}");
                    if (res == 1) return new Response<Employee>("employee deleted");
                    return new Response<Employee>("not found");
                }
            });
        }
        public async Task<Response<Employee>> Update(Employee c)
        {
            return await Task.Run(() =>
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    var res = conn.Execute($"update employee set firstname={c.FirstName},lastname={c.LastName},age={c.Age},gender={c.Gender},address={c.Address},departmentid={c.DepartmentId},position={c.Position} where id={c.Id}");
                    if (res == 1) return new Response<Employee>("employee updated");
                    return new Response<Employee>("not found");
                }
            });
        }
    }
}

