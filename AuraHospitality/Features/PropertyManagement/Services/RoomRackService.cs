using AuraHospitality.Features.PropertyManagement.Models;

namespace AuraHospitality.Features.PropertyManagement.Services;

public interface IRoomRackService
{
    IReadOnlyList<RoomRackItem> GetAllRooms();
    RoomRackItem? GetRoom(string roomNumber);
    void UpdateStatus(string roomNumber, RoomStatusType newStatus);
    void AssignButler(string roomNumber, string butlerName);
    IReadOnlyList<FolioCharge> GetFolioCharges(string roomNumber);
    void AddFolioCharge(string roomNumber, string description, string category, decimal amount);
    event Action? OnRoomsChanged;
}

public class RoomRackService : IRoomRackService
{
    private readonly List<RoomRackItem> _rooms = new()
    {
        new RoomRackItem { RoomNumber = "101", Name = "Azure Overwater Villa 101", Category = "Overwater Villa", Status = RoomStatusType.Occupied, GuestName = "Lord Harrison Blake", CheckOutDate = "Oct 18, 2026", Nights = 5, FolioBalance = 7250m, IsVip = true, AssignedButler = "Ramesh" },
        new RoomRackItem { RoomNumber = "102", Name = "Azure Overwater Villa 102", Category = "Overwater Villa", Status = RoomStatusType.VacantClean, GuestName = null, CheckOutDate = null, Nights = 0, FolioBalance = 0m, IsVip = false, AssignedButler = "Unassigned" },
        new RoomRackItem { RoomNumber = "103", Name = "Azure Overwater Villa 103", Category = "Overwater Villa", Status = RoomStatusType.DirtyTurnover, GuestName = "Departed (Sarah Chen)", CheckOutDate = "Today 11:00", Nights = 3, FolioBalance = 0m, IsVip = false, AssignedButler = "Priya" },
        new RoomRackItem { RoomNumber = "104", Name = "Azure Lagoon Presidential Suite", Category = "Presidential Suite", Status = RoomStatusType.Occupied, GuestName = "Dr. Sophia & Alexander Vance", CheckOutDate = "Oct 22, 2026", Nights = 7, FolioBalance = 14200m, IsVip = true, AssignedButler = "Kavita" },
        new RoomRackItem { RoomNumber = "201", Name = "Belvedere Cliffside Manor 201", Category = "Cliffside Manor", Status = RoomStatusType.Occupied, GuestName = "Marcello Rossi", CheckOutDate = "Oct 19, 2026", Nights = 4, FolioBalance = 6400m, IsVip = true, AssignedButler = "Gianni" },
        new RoomRackItem { RoomNumber = "202", Name = "Belvedere Cliffside Manor 202", Category = "Cliffside Manor", Status = RoomStatusType.Maintenance, GuestName = null, CheckOutDate = null, Nights = 0, FolioBalance = 0m, IsVip = false, AssignedButler = "None" },
        new RoomRackItem { RoomNumber = "301", Name = "Matterhorn Alpine Glass 301", Category = "Alpine Chalet", Status = RoomStatusType.Occupied, GuestName = "Countess Eleanor Wright", CheckOutDate = "Oct 20, 2026", Nights = 6, FolioBalance = 12600m, IsVip = true, AssignedButler = "Hans" },
        new RoomRackItem { RoomNumber = "302", Name = "Matterhorn Penthouse 302", Category = "Alpine Chalet", Status = RoomStatusType.InspectedReady, GuestName = "Arrival at 18:00", CheckOutDate = null, Nights = 0, FolioBalance = 0m, IsVip = true, AssignedButler = "Lukas" },
        new RoomRackItem { RoomNumber = "401", Name = "Serengeti Acacia Pavilion 401", Category = "Safari Pavilion", Status = RoomStatusType.Occupied, GuestName = "David & Maya Lin", CheckOutDate = "Oct 17, 2026", Nights = 3, FolioBalance = 4950m, IsVip = false, AssignedButler = "Juma" },
        new RoomRackItem { RoomNumber = "501", Name = "Komorebi Bamboo Ryokan 501", Category = "Ryokan Sanctuary", Status = RoomStatusType.Occupied, GuestName = "Hiroshi & Yoko Tanaka", CheckOutDate = "Oct 21, 2026", Nights = 4, FolioBalance = 5520m, IsVip = true, AssignedButler = "Akira" },
        new RoomRackItem { RoomNumber = "601", Name = "Caldera Cave Suite 601", Category = "Caldera Suite", Status = RoomStatusType.InspectedReady, GuestName = null, CheckOutDate = null, Nights = 0, FolioBalance = 0m, IsVip = false, AssignedButler = "Nikos" },
        new RoomRackItem { RoomNumber = "701", Name = "Uluwatu Cliff Villa 701", Category = "Ocean Cliff Estate", Status = RoomStatusType.Occupied, GuestName = "Liam & Chloe Hemsworth", CheckOutDate = "Oct 23, 2026", Nights = 8, FolioBalance = 10320m, IsVip = true, AssignedButler = "Wayan" }
    };

    private readonly Dictionary<string, List<FolioCharge>> _folios = new()
    {
        {
            "101",
            new List<FolioCharge>
            {
                new("c1", DateTime.Today.AddDays(-2), "Overwater Villa Night 1 & 2", "Lodging", 2900m),
                new("c2", DateTime.Today.AddDays(-1), "L’Océan Submerged Caviar Dinner", "Dining", 850m),
                new("c3", DateTime.Today.AddDays(-1), "Ayurvedic Herbal Hot Stone Treatment", "Spa", 480m),
                new("c4", DateTime.Today, "Vintage Dom Pérignon Champagne (Butler Reserve)", "Beverage", 620m)
            }
        },
        {
            "104",
            new List<FolioCharge>
            {
                new("c5", DateTime.Today.AddDays(-3), "Presidential Suite Night 1-3", "Lodging", 9600m),
                new("c6", DateTime.Today.AddDays(-2), "Private Yacht Sunset Charter", "Expedition", 2400m),
                new("c7", DateTime.Today.AddDays(-1), "In-Suite Michelin Chef Degustation", "Dining", 1500m),
                new("c8", DateTime.Today, "Spa Royal Couple Immersion", "Spa", 700m)
            }
        }
    };

    public event Action? OnRoomsChanged;

    public IReadOnlyList<RoomRackItem> GetAllRooms() => _rooms.AsReadOnly();

    public RoomRackItem? GetRoom(string roomNumber) => _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

    public void UpdateStatus(string roomNumber, RoomStatusType newStatus)
    {
        var room = GetRoom(roomNumber);
        if (room != null)
        {
            room.Status = newStatus;
            OnRoomsChanged?.Invoke();
        }
    }

    public void AssignButler(string roomNumber, string butlerName)
    {
        var room = GetRoom(roomNumber);
        if (room != null)
        {
            room.AssignedButler = butlerName;
            OnRoomsChanged?.Invoke();
        }
    }

    public IReadOnlyList<FolioCharge> GetFolioCharges(string roomNumber)
    {
        if (_folios.TryGetValue(roomNumber, out var charges))
        {
            return charges.AsReadOnly();
        }
        return new List<FolioCharge>
        {
            new("c-gen-1", DateTime.Today, "Night Accommodation Charge", "Lodging", 1200m),
            new("c-gen-2", DateTime.Today, "Gourmet Welcome Amenities", "In-Room", 180m)
        }.AsReadOnly();
    }

    public void AddFolioCharge(string roomNumber, string description, string category, decimal amount)
    {
        if (!_folios.ContainsKey(roomNumber))
        {
            _folios[roomNumber] = new List<FolioCharge>();
        }

        var charge = new FolioCharge(Guid.NewGuid().ToString(), DateTime.Now, description, category, amount);
        _folios[roomNumber].Add(charge);

        var room = GetRoom(roomNumber);
        if (room != null)
        {
            room.FolioBalance += amount;
        }

        OnRoomsChanged?.Invoke();
    }
}
