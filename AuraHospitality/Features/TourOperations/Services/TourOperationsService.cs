using AuraHospitality.Features.TourOperations.Models;

namespace AuraHospitality.Features.TourOperations.Services;

public interface ITourOperationsService
{
    IReadOnlyList<TourDispatchItem> GetAllDispatches();
    void UpdateStatus(string dispatchId, string newStatus);
    void AddGuestToTour(string dispatchId);
    event Action? OnDispatchesChanged;
}

public class TourOperationsService : ITourOperationsService
{
    private readonly List<TourDispatchItem> _dispatches = new()
    {
        new TourDispatchItem { DispatchId = "OPS-T1", TourTitle = "Serengeti Great Migration Sky & Bush", DepartureTime = "Tomorrow 05:30", BookedParticipants = 6, MaxCapacity = 6, GuideName = "Joseph Ole Saitoti", TransportVehicle = "Air Balloon #3 + Land Cruiser 4", Status = "Confirmed Full" },
        new TourDispatchItem { DispatchId = "OPS-T2", TourTitle = "Bioluminescent Night Dive & Manta Ray", DepartureTime = "Tonight 20:00", BookedParticipants = 4, MaxCapacity = 4, GuideName = "Dr. Elena Rostova", TransportVehicle = "Dhoni Cruiser Coral Star", Status = "Manifest Ready" },
        new TourDispatchItem { DispatchId = "OPS-T3", TourTitle = "Kyoto Secret Temples & Zen Masters", DepartureTime = "Tomorrow 08:30", BookedParticipants = 2, MaxCapacity = 4, GuideName = "Kenjiro Takahashi", TransportVehicle = "Private Lexus LS", Status = "2 Slots Available" },
        new TourDispatchItem { DispatchId = "OPS-T4", TourTitle = "Amalfi Vintage Riva Yacht & Hidden Grottos", DepartureTime = "Today 13:00", BookedParticipants = 5, MaxCapacity = 6, GuideName = "Capitano Marco Esposito", TransportVehicle = "Riva Aquarama \"Bella Vita\"", Status = "En Route" },
        new TourDispatchItem { DispatchId = "OPS-T5", TourTitle = "Matterhorn Heli-Ski & High Glacier", DepartureTime = "Tomorrow 07:00", BookedParticipants = 4, MaxCapacity = 4, GuideName = "Beatrix von Bergen", TransportVehicle = "Air Zermatt Eurocopter AS350", Status = "Weather Permitted" }
    };

    public event Action? OnDispatchesChanged;

    public IReadOnlyList<TourDispatchItem> GetAllDispatches() => _dispatches.AsReadOnly();

    public void UpdateStatus(string dispatchId, string newStatus)
    {
        var item = _dispatches.FirstOrDefault(d => d.DispatchId == dispatchId);
        if (item != null)
        {
            item.Status = newStatus;
            OnDispatchesChanged?.Invoke();
        }
    }

    public void AddGuestToTour(string dispatchId)
    {
        var item = _dispatches.FirstOrDefault(d => d.DispatchId == dispatchId);
        if (item != null && item.BookedParticipants < item.MaxCapacity)
        {
            item.BookedParticipants++;
            if (item.BookedParticipants == item.MaxCapacity)
            {
                item.Status = "Confirmed Full";
            }
            OnDispatchesChanged?.Invoke();
        }
    }
}
