namespace AuraHospitality.Features.ItineraryPlanner.Models;

public record ItineraryActivityItem(
    string Id,
    string Time,
    string Title,
    string Location,
    decimal CostUSD,
    string Category,
    string Icon
);

public class ItineraryDayPlan
{
    public int DayNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<ItineraryActivityItem> Activities { get; set; } = new();
}

public class ItinerarySchedule
{
    public string Destination { get; set; } = "Positano & Amalfi Coast, Italy";
    public int TotalDays => Days.Count;
    public List<ItineraryDayPlan> Days { get; set; } = new();

    public decimal TotalCostUSD => Days.SelectMany(d => d.Activities).Sum(a => a.CostUSD);
    public int EstimatedCarbonKg => Days.Count * 45;
}
