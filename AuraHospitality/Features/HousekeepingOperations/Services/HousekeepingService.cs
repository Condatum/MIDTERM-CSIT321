using AuraHospitality.Features.HousekeepingOperations.Models;

namespace AuraHospitality.Features.HousekeepingOperations.Services;

public interface IHousekeepingService
{
    IReadOnlyList<HousekeepingTicket> GetAllTickets();
    void UpdateTicketStatus(string ticketId, TicketStatus newStatus);
    void CreateTicket(HousekeepingTicket ticket);
    event Action? OnTicketsChanged;
}

public class HousekeepingService : IHousekeepingService
{
    private readonly List<HousekeepingTicket> _tickets = new()
    {
        new HousekeepingTicket { TicketId = "TKT-801", RoomNumber = "101", GuestName = "Lord Harrison Blake", ServiceType = ServiceType.ButlerRequest, Title = "Vintage Dom Pérignon 2012 champagne on ice", Priority = TicketPriority.High, Status = TicketStatus.InProgress, Assignee = "Ramesh", TimeAgo = "12 mins ago" },
        new HousekeepingTicket { TicketId = "TKT-802", RoomNumber = "103", GuestName = "Departed", ServiceType = ServiceType.Housekeeping, Title = "Complete deep clean & sanitization for 16:00 VIP check-in", Priority = TicketPriority.Urgent, Status = TicketStatus.InProgress, Assignee = "Team Alpha", TimeAgo = "24 mins ago" },
        new HousekeepingTicket { TicketId = "TKT-803", RoomNumber = "301", GuestName = "Countess Eleanor Wright", ServiceType = ServiceType.Concierge, Title = "Private ski boot fitting & heli-transfer reservation", Priority = TicketPriority.Medium, Status = TicketStatus.Completed, Assignee = "Hans", TimeAgo = "40 mins ago" },
        new HousekeepingTicket { TicketId = "TKT-804", RoomNumber = "401", GuestName = "David & Maya Lin", ServiceType = ServiceType.ActivityDispatch, Title = "Dawn hot air balloon departure confirmation & picnic basket", Priority = TicketPriority.High, Status = TicketStatus.Pending, Assignee = "Juma", TimeAgo = "1 hr ago" },
        new HousekeepingTicket { TicketId = "TKT-805", RoomNumber = "202", GuestName = "None (Maintenance)", ServiceType = ServiceType.Engineering, Title = "Infinity plunge pool heating temperature sensor calibration", Priority = TicketPriority.Low, Status = TicketStatus.InProgress, Assignee = "Luigi", TimeAgo = "2 hrs ago" }
    };

    public event Action? OnTicketsChanged;

    public IReadOnlyList<HousekeepingTicket> GetAllTickets() => _tickets.AsReadOnly();

    public void UpdateTicketStatus(string ticketId, TicketStatus newStatus)
    {
        var ticket = _tickets.FirstOrDefault(t => t.TicketId == ticketId);
        if (ticket != null)
        {
            ticket.Status = newStatus;
            OnTicketsChanged?.Invoke();
        }
    }

    public void CreateTicket(HousekeepingTicket ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.TicketId))
        {
            ticket.TicketId = $"TKT-{Random.Shared.Next(810, 999)}";
        }
        _tickets.Insert(0, ticket);
        OnTicketsChanged?.Invoke();
    }
}
