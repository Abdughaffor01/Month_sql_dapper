using Domain.DTOs.Quote;
using Domain.Entities;
using Domain.Response;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.Quote;
public interface IQuoteService
{
    Task<Response<string>> AddQuote(AddQuoteDto addQuoteDto, IFormFile? file);
    Task<Response<string>> AddImageByIdQuote(int id,IFormFile file);
    Task<Response<string>> DeleteQuote(int id);
    Task<Response<string>> UpdateQuote(QuotesDto quotesDto, IFormFile? file);
    Task<Response<GetQuoteCountImage>> GetQuoteById(int id);
    Task<Response<List<GetQuoteImage>>> GetQuoteByText(string quote);
    Task<Response<List<GetQuoteImage>>> GetQuotes();
}
