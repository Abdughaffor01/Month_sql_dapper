using Dapper;
using Domain.DTOs.Quote;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Infrastructure.Services.Quote;
public class QuoteService : IQuoteService
{
    private readonly DataContext _dataContext;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public QuoteService(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _dataContext = dataContext;
    }

    public async Task<Response<string>> AddImageByIdQuote(int id, IFormFile file) 
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            var found = await con.QueryFirstOrDefaultAsync($"select * from quotes where id={id}");
            if (found == null) return new Response<string>("not found");
            var res = await con.ExecuteAsync($"insert into quote_image(quote_id,image_name)values({id},'{file.FileName}');");
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts", file.FileName);
            using var stream = File.Create(fullpath);
            file.CopyTo(stream);
            return new Response<string>("successfuly added image");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> AddQuote(AddQuoteDto addQuoteDto, IFormFile? file)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = "insert into quotes(quote_text,category_id) values(@QuoteText,@CategoryId)";
            if (file == null)
            {
                var res = await con.ExecuteAsync(sql + ";", new { addQuoteDto.QuoteText, addQuoteDto.CategoryId });
                if (res == 0) return new Response<string>("error");
                return new Response<string>("Successful added quote");
            }
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts", file.FileName);
            using var stream = File.Create(fullpath);
            file.CopyTo(stream);
            var id = await con.QuerySingleAsync<int>(sql + "returning id;", new { addQuoteDto.QuoteText, addQuoteDto.CategoryId });
            string sql1 = $"insert into quote_image(quote_id,image_name)values({id},'{file.FileName}');";
            var response = await con.ExecuteAsync(sql1);
            if (id == 0 && response == 0) return new Response<string>("error");
            return new Response<string>("Successful added quote with image");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> DeleteQuote(int id)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            var listimage = await con.QueryAsync<string>($"select image_name from quote_image where quote_id={id}");
            string sql = $"delete from quotes where id={id};", quoteiamge = $"delete from quote_image  where quote_id={id};";
            var resimage = await con.ExecuteAsync(quoteiamge);
            var res = await con.ExecuteAsync(sql);
            foreach (var i in listimage)
            {
                string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts", i);
                File.Delete(fullpath);
            }
            if (res == 1 && resimage == 1) return new Response<string>("deleted quote with image");
            else if (res == 1) return new Response<string>("deleted quote");
            return new Response<string>("not found");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> UpdateQuote(QuotesDto quotesDto, IFormFile? file)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"update quotes set quote_text='{quotesDto.QuoteText}',category_id={quotesDto.CategoryId} where id={quotesDto.Id};";
            var res = await con.ExecuteAsync(sql);
            if (file == null)
            {
                if (res == 0) return new Response<string>("not found");
                return new Response<string>("Successfuly updated quote");
            }
            var namesimage = await con.QueryAsync<string>($"select image_name from quote_image where quote_id={quotesDto.Id}");
            var delim = await con.ExecuteAsync($"delete from quote_image where quote_id={quotesDto.Id}");
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts", file.FileName);
            using var stream = File.Create(fullpath);
            file.CopyTo(stream);
            foreach (var i in namesimage)
            {
                string fullpathdel = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts", i);
                File.Delete(fullpathdel);
            }
            var im = await con.ExecuteAsync($"insert into quote_image(quote_id,image_name) values({quotesDto.Id},'{file.FileName}')");
            if (namesimage == null) return new Response<string>("Updated quote added image");
            return new Response<string>("Updated quote with images");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetQuoteCountImage>> GetQuoteById(int id)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            int sch = await con.ExecuteScalarAsync<int>($"select count(*) from quote_image where quote_id={id};");
            string sql = $"select id as Id,quote_text as QuoteText,category_id as CategoryId from quotes where id ={id};";
            var res = await con.QueryFirstOrDefaultAsync<GetQuoteCountImage>(sql);
            if (res == null) return new Response<GetQuoteCountImage>("not found");
            res.CountImage = sch;
            return new Response<GetQuoteCountImage>("Found quote", res);
        }
        catch (Exception ex)
        {
            return new Response<GetQuoteCountImage>(ex.Message);
        }
    }

    public async Task<Response<List<GetQuoteImage>>> GetQuoteByText(string quote)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            string sql = "select q.id as Id,q.quote_text as QuoteText,q.category_id as CategoryId,im.image_name as File from quotes q " +
                $"full join quote_image im on im.quote_id=q.id where lower(q.quote_text) like '%{quote.ToLower()}%'";
            var res = await con.QueryAsync<GetQuoteImage>(sql);
            if(res==null)return new Response<List<GetQuoteImage>>("not found");
            return new Response<List<GetQuoteImage>>("Successfuly found quote",res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<GetQuoteImage>>(ex.Message);
        }
    }

    public async Task<Response<List<GetQuoteImage>>> GetQuotes()
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = "select q.id as Id,q.quote_text as QuoteText,q.category_id as CategoryId,im.image_name as File from quotes q " +
                $"full join quote_image im on im.quote_id=q.id";
            var res = await con.QueryAsync<GetQuoteImage>(sql);
            if (res == null) return new Response<List<GetQuoteImage>>("not found");
            return new Response<List<GetQuoteImage>>("Successfuly found quote", res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<GetQuoteImage>>(ex.Message);
        }
    }
}
