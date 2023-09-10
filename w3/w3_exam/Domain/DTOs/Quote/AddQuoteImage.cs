using Microsoft.AspNetCore.Http;
namespace Domain.DTOs.Quote;
public class AddQuoteImage : AddQuoteDto
{
    public IFormFile File { get; set; }
}
