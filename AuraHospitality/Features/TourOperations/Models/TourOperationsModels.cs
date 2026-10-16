namespace AuraHospitality.Features.TourOperations.Models;

public class TourDispatchItem
{
    public string DispatchId { get; set; } = string.Empty;
    public string TourTitle { get; set; } = string.Empty;
    public string DepartureTime { get; set; } = string.Empty;
    public int BookedParticipants { get; set; }
    public int MaxCapacity { get; set; }
    public string GuideName { get; set; } = string.Empty;
    public string TransportVehicle { get; set; } = string.Empty;
    public string Status { get; set; } = "Confirmed";
}
