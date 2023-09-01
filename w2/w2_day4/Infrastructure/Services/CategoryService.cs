using Dapper;
using Domein.Model;
using Infrastructure.Services.Generics;
using Npgsql;
namespace Infrastructure.Services;
public class CategoryService:IBaseServices<Category>
{
    string cons="Server=localhost;Port=5432;Database=Quetion;User Id=postgres;Password=987849660;";
    public async Task<Responce<Category>> Add(Category obj)
    {
        return await Task.Run(()=>{
            using(var con= new NpgsqlConnection(cons)){
                var res=con.Execute($"insert into(name) values('{obj.Name}')");
                if(res==0)return new Responce<Category>("error");
                return new Responce<Category>("Successful added");
            }
        });
    }
    public async Task<Responce<Category>> Delete(int id)
    {
        return await Task.Run(()=>{
            using(var con= new NpgsqlConnection(cons)){
                var res=con.Execute($"delete from category where id={id}");
                if(res==0) return new Responce<Category>("not found");
                return new Responce<Category>("Successful deleted");
            }
        });
    }
    public async Task<Responce<Category>> GetAll()
    {
        return await Task.Run(()=>{
            using(var con= new NpgsqlConnection(cons)){
                var res=con.Query<Category>("select* from category").ToList();
                if(res!=null)return new Responce<Category>("Category",res);
                return new Responce<Category>("Not found",res);
            }
        });
    }

    public async Task<Responce<Category>> GetById(int id)
    {
        return await Task.Run(()=>{
            using(var con= new NpgsqlConnection(cons)){
                var res=con.Query<Category>("select* from category").ToList();
                if(res!=null)return new Responce<Category>("Category",res);
                return new Responce<Category>("Not found",res);
            }
        });
    }

    public Task<Responce<Category>> Update(Category obj)
    {
        throw new NotImplementedException();
    }
}
