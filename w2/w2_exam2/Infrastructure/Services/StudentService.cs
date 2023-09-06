using Dapper;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;
public class StudentService : IBaseServices<Student>
{
    DataContext _context= new DataContext();
    public async Task<Responce<Student>> Add(Student obj)
    {
        try
        {
               using var con = _context.createcontext();
               string sql = $"insert into student(first_name,last_name,phone,group_id) values('{obj.FirstName}','{obj.LastName}','{obj.Phone}',{obj.GroupId})";
               var res =await con.ExecuteAsync(sql);
               if(res==0) return new Responce<Student>("not found");
               return new Responce<Student>("added");
        }
        catch (Exception)
        {
            return new Responce<Student>("error");
        }   
    }
    public async Task<Responce<Student>> Delete(int id)
    {
        try
        {
                using var con = _context.createcontext();
                string sql = $"delete from student where id={id}";
                var res = await con.ExecuteAsync(sql);
                if(res==0) return new Responce<Student>("not found");
                return new Responce<Student>("deleted");
        }
        catch (Exception)
        {
            return new Responce<Student>("error");
        }   
    }
    public async Task<Responce<Student>> GetAll()
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select id as Id, first_name as FirstName,last_name as LastName,phone as Phone,group_id as GroupId from student";
            var res = await con.QueryAsync<Student>(sql);
            if (res == null) return new Responce<Student>("not found");
            return new Responce<Student>("yess",res.ToList());
        }
        catch (Exception)
        {
            return new Responce<Student>("error");
        }
    }
    public async Task<Responce<Student>> GetById(int id)
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select first_name as FirstName,last_name as LastName,phone as Phone,group_id as GroupId from student where id={id}";
            var res = await con.QueryFirstOrDefaultAsync<Student>(sql);
            if (res == null) return new Responce<Student>("not found");
            return new Responce<Student>("yraaaa",res);
        }
        catch (Exception)
        {
            return new Responce<Student>("error");
        }
    }
    public async Task<Responce<Student>> Update(Student obj)
    {
        try
        {
                using var con = _context.createcontext();
                string sql =
                    $"update student set first_name={obj.FirstName},lastname={obj.LastName},phone={obj.Phone},group_id={obj.GroupId} where id={obj.Id}";
                var res = await con.ExecuteAsync(sql);
                if(res==0) return new Responce<Student>("not found");
                return new Responce<Student>("updated");
        }
        catch (Exception)
        {
            return new Responce<Student>("error");
        }  
    }
}
