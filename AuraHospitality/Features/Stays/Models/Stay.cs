namespace AuraHospitality.Features.Stays.Models;

public record Stay(
    string Id,
    string Name,
    string Destination,
    string Category,
    string Tag,
    decimal PricePerNight,
    double Rating,
    int ReviewsCount,
    List<string> Images,
    string Description,
    int Bedrooms,
    int Bathrooms,
    int MaxGuests,
    int SizeSqM,
    List<string> Amenities,
    List<string> Features
);

public class StayFilterCriteria
{
    public string Category { get; set; } = "All";
    public string SearchQuery { get; set; } = string.Empty;
    public decimal? MaxPrice { get; set; }
    public double MinRating { get; set; } = 0;
}
