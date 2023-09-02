using Dapper;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;
public class CategoryService:IBaseServices<Category>
{
    DataContext _context= new DataContext();
    public async Task<Responce<Category>> Add(Category obj)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"insert into category(name) values('{obj.Name}')");
                    if(res==0)return new Responce<Category>("error");
                    return new Responce<Category>("Successful added");
                }
            }); 
        }
        catch (System.Exception)
        {
            return new Responce<Category>("Error !!! types");
        }
    }
    public async Task<Responce<Category>> Delete(int id)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"delete from category where id={id}");
                    if(res==0) return new Responce<Category>("not found");
                    return new Responce<Category>("Successful deleted");
                }
            });
        }
        catch (System.Exception)
        {
            return new Responce<Category>("Error !!! types");
        }
    }
    public async Task<Responce<Category>> GetAll()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<Category>("select id as Id,name as Name from category").ToList();
                    if(res!=null)return new Responce<Category>("Category",res);
                    return new Responce<Category>("Not found");
                }
            }); 
        }
        catch (System.Exception)
        {
           return new Responce<Category>("Error !!! types");
        }
    }
    public async Task<Responce<Category>> GetById(int id)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.QueryFirstOrDefault<Category>($"select id as Id, name as Name from category where id={id}");
                    if(res!=null)return new Responce<Category>("Category",res);
                    return new Responce<Category>("Not found");
                }
            }); 
        }
        catch (System.Exception)
        {
           return new Responce<Category>("Error !!! types");
        }
    }
    public async Task<Responce<Category>> Update(Category obj)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"update category set name='{obj.Name}' where id={obj.Id}");
                    if(res!=0)return new Responce<Category>("Successful updated category");
                    return new Responce<Category>("Not found");
                }
            });  
        }
        catch (System.Exception)
        {
            return new Responce<Category>("Error !!! types");
        }
    }
}
