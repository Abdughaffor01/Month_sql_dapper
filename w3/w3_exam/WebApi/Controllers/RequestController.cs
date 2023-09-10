using Domain.DTOs.Request;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class RequestController : ControllerBase
{
    private readonly IRequest _request;
    public RequestController(IRequest request) => _request = request;

    [HttpGet("GetQuotesWithCategory")]
    public async Task<Response<QuotesWithCategory>> GetQuotesWithCategory(int? id, string? name) => await _request.GetQuotesWithCategory(id, name);


    [HttpGet("RandomQuote")]
    public async Task<Response<QuotesDto>> RandomQuote()=>await _request.RandomQuote();
}
