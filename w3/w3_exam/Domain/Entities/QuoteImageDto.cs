using Microsoft.AspNetCore.Http;

namespace Domain.Entities;
public class QuoteImageDto
{
    public int Id { get; set; }
    public int QuoteId { get; set; }
    public IFormFile? MyProperty { get; set; }
}
