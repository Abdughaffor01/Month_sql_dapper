using Domain.DTOs.Request;
using Domain.Entities;
using Domain.Response;

namespace Infrastructure.Services;
public interface IRequest
{
    Task<Response<QuotesWithCategory>> GetQuotesWithCategory(int? id,string? name);
    Task<Response<QuotesDto>> RandomQuote();
}
