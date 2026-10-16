namespace AuraHospitality.Features.Tours.Models;

public record TourGuide(string Name, string Title, string Avatar);

public record Tour(
    string Id,
    string Title,
    string Destination,
    string Category,
    string Tag,
    decimal PricePerPerson,
    string Duration,
    double Rating,
    int ReviewsCount,
    string Difficulty,
    string GroupSize,
    string Image,
    string Description,
    List<string> Highlights,
    TourGuide Guide,
    List<string> Includes
);

public class TourFilterCriteria
{
    public string Category { get; set; } = "All";
    public string SearchQuery { get; set; } = string.Empty;
    public decimal? MaxPrice { get; set; }
    public string? Difficulty { get; set; }
}
