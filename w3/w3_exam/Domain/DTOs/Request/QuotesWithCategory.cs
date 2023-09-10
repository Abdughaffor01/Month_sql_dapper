using Domain.Entities;
namespace Domain.DTOs.Request;
public class QuotesWithCategory
{
    public string? CategoryName { get; set; }
    public List<GetQuotes>? Quotes { get; set; }
}
