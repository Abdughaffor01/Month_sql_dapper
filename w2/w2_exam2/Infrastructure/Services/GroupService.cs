using Dapper;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;
public class GroupService : IBaseServices<Groups>
{
    DataContext _context= new DataContext();
    public async Task<Responce<Groups>> Add(Groups obj)
    {
        try
        {
            using var con = _context.createcontext();
            string sql = $"insert into groups(group_name,title) values('{obj.GroupsName}','{obj.Title}')";
            var res = await con.ExecuteAsync(sql);
            if (res == 0) return new Responce<Groups>("Not found");
            return new Responce<Groups>("Added");
        }
        catch (Exception)
        {
            return new Responce<Groups>("Error");
        }
    }
    public async Task<Responce<Groups>> Delete(int id)
    {
        try
        {
                using var con=_context.createcontext();
                string sql = $"delete from groups where id={id}";
                var res =await con.ExecuteAsync(sql);
                if(res==0) return new Responce<Groups>("Not found");
                return new Responce<Groups>("deleted");
        }
        catch (Exception)
        {
            return new Responce<Groups>("Error");
        }
    }
    public async Task<Responce<Groups>> GetAll()
    {
        try
        {
                using var con=_context.createcontext();
                string sql = "Select group_name as GroupsName,title as Title from groups";
                var res= await con.QueryAsync<Groups>(sql);
                if(res==null) new Responce<Groups>("not found");
                return new Responce<Groups>("Yesssss",res.ToList());
        }
        catch (Exception)
        {
            return new Responce<Groups>("Error");
        }
    }
    public async Task<Responce<Groups>> GetById(int id)
    {
        try
        {
                using var con=_context.createcontext();
                string sql = $"select group_name as GroupsName,title as Title from groups where id={id}";
                var res=await con.QueryFirstOrDefaultAsync<Groups>(sql);
                if(res==null) return new Responce<Groups>("Not found");
                return new Responce<Groups>("yesss",res);
        }
        catch (Exception)
        {
            return new Responce<Groups>("Error");
        }
    }
    public async Task<Responce<Groups>> Update(Groups obj)
    {
        try
        {
                using var con=_context.createcontext();
                string sql = $"update groups set group_name='{obj.GroupsName}',title='{obj.Title}' where id={obj.Id}";
                var res=con.Execute(sql);
                if(res==0) return new Responce<Groups>("Not found");
                return new Responce<Groups>("updated");
        }
        catch (Exception)
        {
            return new Responce<Groups>("Error");
        }
    }
}


