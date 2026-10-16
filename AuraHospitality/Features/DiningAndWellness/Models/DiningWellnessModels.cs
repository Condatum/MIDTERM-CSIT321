namespace AuraHospitality.Features.DiningAndWellness.Models;

public record CulinaryWellnessItem(
    string Id,
    string Name,
    string Type, // "Dining" or "Wellness"
    string Destination,
    string CuisineOrSpecialty,
    double Rating,
    string PriceTier,
    string ImageUrl,
    string Description,
    string SignatureOffering
);

public class DiningWellnessReservationRequest
{
    public string ExperienceId { get; set; } = string.Empty;
    public string ExperienceName { get; set; } = string.Empty;
    public string GuestName { get; set; } = "Alexandra Vance";
    public DateTime Date { get; set; } = DateTime.Today.AddDays(2);
    public string TimeSlot { get; set; } = "19:30";
    public int Guests { get; set; } = 2;
    public string SpecialNotes { get; set; } = "Caldera sunset view table preferred.";
}
