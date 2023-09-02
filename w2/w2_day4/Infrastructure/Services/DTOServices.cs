using Dapper;
using Domein.DTO;
using Domein.Model;
using Infrastructure.Data;
using Infrastructure.Services.Generics;
namespace Infrastructure.Services;
public class DTOServices
{
    DataContext _context= new DataContext();
    public async Task<Responce<CategoryQuotesDTO>> CategoryQuotes()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<CategoryQuotesDTO>($"select quotestext as Quotes ,name as Category from category join quotes on category.id=quotes.categoryid").ToList();
                    if(res!=null)return new Responce<CategoryQuotesDTO>("Successful",res);
                    return new Responce<CategoryQuotesDTO>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<CategoryQuotesDTO>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> QuotesByCategory(int id)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<Quotes>($"select author as Author,quotestext as QuotesText,categoryid as CategoryId from quotes where categoryid={id}").ToList();
                    if(res!=null)return new Responce<Quotes>("Successful",res);
                    return new Responce<Quotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> RandomQuotes()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.QueryFirstOrDefault<Quotes>($"select author as Author,quotestext as QuotesText,categoryid as CategoryId from quotes order by random()");
                    if(res!=null)return new Responce<Quotes>("Successful",res);
                    return new Responce<Quotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<CountCategoryQuotes>> CountQuoteCategory()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<CountCategoryQuotes>($"select name as Name,count(*) as Count from category  join quotes q on category.id=q.categoryid group by name").ToList();
                    if(res!=null)return new Responce<CountCategoryQuotes>("Successful",res);
                    return new Responce<CountCategoryQuotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<CountCategoryQuotes>("Error !!! types");
        }
    }
    public async Task<Responce<CountCategoryQuotes>> AuthorCountQuote()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<CountCategoryQuotes>($"select author as Name,count(*) as Count from quotes group by author").ToList();
                    if(res!=null)return new Responce<CountCategoryQuotes>("Successful",res);
                    return new Responce<CountCategoryQuotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<CountCategoryQuotes>("Error !!! types");
        }
    }
    public async Task<Responce<CountTwo>> CountAuthorAndQuotes()
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.QueryFirstOrDefault<CountTwo>($"select distinct count(author) as CountOne,sum(categoryid) as CountTwoo from quotes");
                    if(res!=null)return new Responce<CountTwo>("Successful",res);
                    return new Responce<CountTwo>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<CountTwo>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> FilterQuotes(string text)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<Quotes>($"select author as Author,quotestext as QuotesText,categoryid as CategoryId from quotes where quotestext like '%{text}%'").ToList();
                    if(res!=null)return new Responce<Quotes>("Successful",res);
                    return new Responce<Quotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }
    public async Task<Responce<Quotes>> TopAuthoe(string text)
    {
        try
        {
            return await Task.Run(()=>{
                using(var con = _context._DataContext()){
                    var res=con.Query<Quotes>($"select author as Name,count(*) as Count from quotes group by author having count(author)>=2").ToList();
                    if(res!=null)return new Responce<Quotes>("Successful",res);
                    return new Responce<Quotes>("not found");
                }
            }); 
        }
        catch (Exception)
        {
            return new Responce<Quotes>("Error !!! types");
        }
    }

}
