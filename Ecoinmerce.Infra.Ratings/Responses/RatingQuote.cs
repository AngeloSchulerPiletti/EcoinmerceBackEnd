namespace Ecoinmerce.Infra.Ratings.Responses;

public class RatingQuote
{
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CurrencyFrom { get; set; }
    public string CurrencyTo { get; set; }
}
