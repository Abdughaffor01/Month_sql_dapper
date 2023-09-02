using Dapper;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;

public class QuotesService:IBaseServices<Quotes>
{
    DataContext _context= new DataContext();
    public async Task<Responce<Quotes>> Add(Quotes obj)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"insert into quotes(author,quotestext,categoryid) values('{obj.Author}','{obj.QuotesText}','{obj.CategoryId}')");
                    if(res==0)return new Responce<Quotes>("error");
                    return new Responce<Quotes>("Successful added");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> Delete(int id)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"delete from quotes where id={id}");
                    if(res==0) return new Responce<Quotes>("not found");
                    return new Responce<Quotes>("Successful deleted");
                }
            });
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> GetAll()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<Quotes>("select author as Author,quotestext as QuotesText,categoryid as CategoryId from quotes").ToList();
                    if(res!=null)return new Responce<Quotes>("Quotes",res);
                    return new Responce<Quotes>("Not found");
                }
            }); 
        }
        catch (Exception)
        {
           return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> GetById(int id)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.QueryFirstOrDefault<Quotes>($"select author as Author,quotestext as QuotesText,categoryid as CategoryId from quotes where id={id}");
                    if(res!=null)return new Responce<Quotes>("Quotes",res);
                    return new Responce<Quotes>("Not found");
                }
            }); 
        }
        catch (Exception)
        {
           return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> Update(Quotes obj)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Execute($"update category set author='{obj.Author}',quotestext='{obj.QuotesText}',categoryid={obj.CategoryId} where id={obj.Id}");
                    if(res!=0)return new Responce<Quotes>("Successful updated qoute");
                    return new Responce<Quotes>("Not found");
                }
            });  
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
}
