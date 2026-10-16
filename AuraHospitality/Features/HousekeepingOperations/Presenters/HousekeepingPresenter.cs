using AuraHospitality.Features.HousekeepingOperations.Models;
using AuraHospitality.Features.HousekeepingOperations.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.HousekeepingOperations.Presenters;

public interface IHousekeepingView
{
    void DisplayTickets(IReadOnlyList<HousekeepingTicket> tickets);
    void ShowCreateModal(bool isOpen);
}

public class HousekeepingPresenter
{
    private readonly IHousekeepingService _service;
    private readonly IAppStateService _appState;
    private IHousekeepingView? _view;

    public string StatusFilter { get; private set; } = "All";

    public HousekeepingPresenter(
        IHousekeepingService service,
        IAppStateService appState)
    {
        _service = service;
        _appState = appState;

        _service.OnTicketsChanged += HandleTicketsChanged;
    }

    public void AttachView(IHousekeepingView view)
    {
        _view = view;
        RefreshTickets();
    }

    private void HandleTicketsChanged()
    {
        RefreshTickets();
    }

    public void FilterByStatus(string status)
    {
        StatusFilter = status;
        RefreshTickets();
    }

    private void RefreshTickets()
    {
        var all = _service.GetAllTickets();
        var filtered = StatusFilter == "All"
            ? all
            : all.Where(t => t.Status.ToString().Equals(StatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();

        _view?.DisplayTickets(filtered);
    }

    public void AdvanceTicketStatus(string ticketId)
    {
        var ticket = _service.GetAllTickets().FirstOrDefault(t => t.TicketId == ticketId);
        if (ticket == null) return;

        var nextStatus = ticket.Status switch
        {
            TicketStatus.Pending => TicketStatus.InProgress,
            TicketStatus.InProgress => TicketStatus.Completed,
            _ => TicketStatus.Pending
        };

        _service.UpdateTicketStatus(ticketId, nextStatus);
        _appState.PushNotification("Dispatch Updated", $"Ticket {ticketId} moved to {nextStatus}.", Core.Models.NotificationType.Info);
    }

    public void OpenCreateModal() => _view?.ShowCreateModal(true);
    public void CloseCreateModal() => _view?.ShowCreateModal(false);

    public void SubmitNewTicket(HousekeepingTicket ticket)
    {
        _service.CreateTicket(ticket);
        _view?.ShowCreateModal(false);
        _appState.PushNotification("Service Ticket Dispatched", $"New {ticket.ServiceType} request created for Room {ticket.RoomNumber}.", Core.Models.NotificationType.Success);
    }
}
