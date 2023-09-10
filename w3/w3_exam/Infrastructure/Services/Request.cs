using Dapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Context;
namespace Infrastructure.Services;
public class Request : IRequest
{
    private readonly DataContext _dataContext;
    public Request(DataContext dataContext)=>_dataContext = dataContext;

    public async  Task<Response<QuotesWithCategory>> GetQuotesWithCategory(int? id, string? name)
    {
		try
		{
			using var con=_dataContext.CreateConnection();
			var quotes = await con.QueryAsync<GetQuotes>($"select id as Id,quote_text as QuoteText from quotes where category_id={id};");
			if (name == null) {
                var category = await con.QueryFirstOrDefaultAsync<QuotesWithCategory>($"select category_name as CategoryName from category where id={id};");
                category.Quotes = quotes.ToList();
				return new Response<QuotesWithCategory>("Successfuly founded", category);
            }
            var categoryname = await con.QueryFirstOrDefaultAsync<QuotesWithCategory>($"select category_name as CategoryName from category where lower(category_name) like '%{name.ToLower()}%';");
            categoryname.Quotes = quotes.ToList();
            if (categoryname == null) return new Response<QuotesWithCategory>("not found");
            return new Response<QuotesWithCategory>("Successfuly founded", categoryname);
        }
		catch (Exception ex)
		{
			return new Response<QuotesWithCategory>(ex.Message);
		}
    }

    public async Task<Response<QuotesDto>> RandomQuote()
    {
		try
		{
			using var con = _dataContext.CreateConnection();
			var res = await con.QueryFirstOrDefaultAsync<QuotesDto>("select id as Id,quote_text as QuoteText,category_id as CategoryId from quotes order by random()");
			if (res == null) return new Response<QuotesDto>("not found");
			return new Response<QuotesDto>("Successfuly found",res);
		}
		catch (Exception ex)
		{
			return new Response<QuotesDto>(ex.Message);
		}
    }
}
