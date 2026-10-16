namespace AuraHospitality.Features.PropertyManagement.Models;

public enum RoomStatusType
{
    Occupied,
    VacantClean,
    DirtyTurnover,
    Maintenance,
    InspectedReady
}

public class RoomRackItem
{
    public string RoomNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public RoomStatusType Status { get; set; }
    public string? GuestName { get; set; }
    public string? CheckOutDate { get; set; }
    public int Nights { get; set; }
    public decimal FolioBalance { get; set; }
    public bool IsVip { get; set; }
    public string AssignedButler { get; set; } = "Unassigned";
}

public record FolioCharge(
    string Id,
    DateTime Date,
    string Description,
    string Category,
    decimal Amount
);
