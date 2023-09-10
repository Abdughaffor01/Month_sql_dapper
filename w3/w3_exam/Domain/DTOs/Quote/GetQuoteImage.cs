using Domain.Entities;

namespace Domain.DTOs.Quote;

public class GetQuoteImage:QuotesDto
{
    public string File { get; set; } = "not image";
}
