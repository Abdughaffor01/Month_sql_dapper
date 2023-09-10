namespace Domain.Entities;
public class QuotesDto
{
    public int Id { get; set; }
    public string? QuoteText { get; set; }
    public int CategoryId { get; set; }
}
