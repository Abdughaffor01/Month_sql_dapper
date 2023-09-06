using Dapper;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;

public class DTOServices
{
    DataContext _context= new DataContext();
    public async Task<Responce<List<Student>>> GetStudentByGroup(int id)
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select first_name as FirstName,last_name as LastName,phone as Phone,group_id as GroupId from student where group_id={id}";
            var res = await con.QueryAsync<Student>(sql);
            if (res == null) return new Responce<List<Student>>("not found");
            return new Responce<List<Student>>("yess",res.ToList());
        }
        catch (Exception)
        {
            return new Responce<List<Student>>("Error");
        }
    }
    public async Task<Responce<Student>> GetRandomStudent()
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select first_name as FirstName,last_name as LastName,phone as Phone,group_id as GroupId from student order by random()";
            var res = await con.QueryFirstOrDefaultAsync<Student>(sql);
            if (res == null) return new Responce<Student>("not found");
            return new Responce<Student>("yraaaa",res);
        }
        catch (Exception)
        {
            return new Responce<Student>("Error");
        }
    }
    public async Task<Responce<List<DTOStudentWithGroups>>> GetStudentGroup()
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select concat(s.first_name,' ',s.last_name) as FullName , g.group_name as GroupName from student s join groups g on g.id=s.group_id";
            var res = await con.QueryAsync<DTOStudentWithGroups>(sql);
            if (res == null) return new Responce<List<DTOStudentWithGroups>>("not found");
            return new Responce<List<DTOStudentWithGroups>>("yraaaa",res.ToList());
        }
        catch (Exception)
        {
            return new Responce<List<DTOStudentWithGroups>>("Error");
        }
    }
    public async Task<Responce<DTOGroupsWithStudents>> GroupsWithStudents()
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"Select id as Id, group_name as GroupsName,title as Title from groups";
            string sql1 = $"select id as Id,first_name as FirstName,last_name as LastName,phone as Phone,group_id as GroupId from student";
            var students = await con.QueryAsync<Student>(sql1);
            var groups = await con.QueryAsync<Groups>(sql);
            DTOGroupsWithStudents res=new DTOGroupsWithStudents();
            res.Groups = groups.ToList();
            res.Student = students.ToList();
            if (res == null) return new Responce<DTOGroupsWithStudents>("not found");
            return new Responce<DTOGroupsWithStudents>("yraaaa",res);
        }
        catch (Exception)
        {
            return new Responce<DTOGroupsWithStudents>("Error");
        }
    }public async Task<Responce<DTOGroupByIdStudents>> GroupsByIdWithStudents(int id)
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"select  group_name as GroupName from groups where id={id}";
            string sql1 = $"select concat(first_name,' ',last_name) as fullname from student where group_id={id}";
            var student = await con.QueryAsync<string>(sql1);
            var res = await con.QueryFirstOrDefaultAsync<DTOGroupByIdStudents>(sql);
            res.Students = student.ToList();
            if (res == null) return new Responce<DTOGroupByIdStudents>("not found");
            return new Responce<DTOGroupByIdStudents>("uraaaa",res);
        }
        catch (Exception)
        {
            return new Responce<DTOGroupByIdStudents>("Error");
        }
    }
}