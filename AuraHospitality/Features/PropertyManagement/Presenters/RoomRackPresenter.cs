using AuraHospitality.Features.PropertyManagement.Models;
using AuraHospitality.Features.PropertyManagement.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.PropertyManagement.Presenters;

public interface IRoomRackView
{
    void DisplayRooms(IReadOnlyList<RoomRackItem> rooms);
    void DisplaySelectedRoom(RoomRackItem? room, IReadOnlyList<FolioCharge> charges);
    void ShowNotification(string title, string message, bool isSuccess);
}

public class RoomRackPresenter
{
    private readonly IRoomRackService _roomRackService;
    private readonly ICurrencyService _currencyService;
    private readonly IAppStateService _appState;
    private IRoomRackView? _view;

    public string StatusFilter { get; private set; } = "All";

    public RoomRackPresenter(
        IRoomRackService roomRackService,
        ICurrencyService currencyService,
        IAppStateService appState)
    {
        _roomRackService = roomRackService;
        _currencyService = currencyService;
        _appState = appState;

        _roomRackService.OnRoomsChanged += HandleRoomsChanged;
    }

    public void AttachView(IRoomRackView view)
    {
        _view = view;
        RefreshRooms();
    }

    private void HandleRoomsChanged()
    {
        RefreshRooms();
    }

    public void FilterByStatus(string status)
    {
        StatusFilter = status;
        RefreshRooms();
    }

    private void RefreshRooms()
    {
        var allRooms = _roomRackService.GetAllRooms();
        var filtered = StatusFilter == "All" 
            ? allRooms 
            : allRooms.Where(r => r.Status.ToString().Equals(StatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();

        _view?.DisplayRooms(filtered);
    }

    public void SelectRoomForInspection(string roomNumber)
    {
        var room = _roomRackService.GetRoom(roomNumber);
        if (room != null)
        {
            var charges = _roomRackService.GetFolioCharges(roomNumber);
            _view?.DisplaySelectedRoom(room, charges);
        }
    }

    public void CloseRoomModal()
    {
        _view?.DisplaySelectedRoom(null, Array.Empty<FolioCharge>());
    }

    public void UpdateRoomStatus(string roomNumber, RoomStatusType status)
    {
        _roomRackService.UpdateStatus(roomNumber, status);
        _appState.PushNotification("Room Rack Updated", $"Room {roomNumber} is now marked as {status}.", Core.Models.NotificationType.Success);
        
        // Re-inspect updated room if modal is active
        var room = _roomRackService.GetRoom(roomNumber);
        if (room != null)
        {
            var charges = _roomRackService.GetFolioCharges(roomNumber);
            _view?.DisplaySelectedRoom(room, charges);
        }
    }

    public void PostCharge(string roomNumber, string description, string category, decimal amount)
    {
        _roomRackService.AddFolioCharge(roomNumber, description, category, amount);
        _appState.PushNotification("Folio Charge Posted", $"Added {_currencyService.FormatPrice(amount)} to Room {roomNumber}.", Core.Models.NotificationType.Success);

        var room = _roomRackService.GetRoom(roomNumber);
        if (room != null)
        {
            var charges = _roomRackService.GetFolioCharges(roomNumber);
            _view?.DisplaySelectedRoom(room, charges);
        }
    }
}
