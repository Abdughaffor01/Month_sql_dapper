using Domain.DTOs.Quote;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services.Quote;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteService _quoteService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public QuoteController(IQuoteService quoteService, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _quoteService = quoteService;
    }

    [HttpPost("AddImageByIdQuote")]
    public async Task<Response<string>> AddImageByIdQuote(int id, IFormFile file)=>await _quoteService.AddImageByIdQuote(id, file);

    [HttpPost("AddQuote")]
    public async Task<Response<string>> AddQuote([FromForm] AddQuoteDto addQuoteDto, IFormFile? file) => await _quoteService.AddQuote(addQuoteDto, file);

    [HttpDelete("DeleteQuote")]
    public async Task<Response<string>> DeleteQuote([FromForm] int id) => await _quoteService.DeleteQuote(id);

    [HttpPut("UpdateQuote")]
    public async Task<Response<string>> UpdateQuote([FromForm]QuotesDto quotesDto, IFormFile? file)=>await _quoteService.UpdateQuote(quotesDto, file);

    [HttpGet("GetQuoteById_WithCountImage")]
    public async Task<Response<GetQuoteCountImage>> GetQuoteById(int id) => await _quoteService.GetQuoteById(id);

    [HttpGet("GetQuoteByText")]
    public async Task<Response<List<GetQuoteImage>>> GetQuoteByText(string quote)=>await _quoteService.GetQuoteByText(quote);

    [HttpGet("GetQuotes")]
    public async Task<Response<List<GetQuoteImage>>> GetQuotes()=>await _quoteService.GetQuotes();
}
