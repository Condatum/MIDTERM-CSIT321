namespace AuraHospitality.Features.HousekeepingOperations.Models;

public enum ServiceType
{
    ButlerRequest,
    Housekeeping,
    Concierge,
    ActivityDispatch,
    Engineering
}

public enum TicketPriority
{
    Low,
    Medium,
    High,
    Urgent
}

public enum TicketStatus
{
    Pending,
    InProgress,
    Completed
}

public class HousekeepingTicket
{
    public string TicketId { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public ServiceType ServiceType { get; set; }
    public string Title { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }
    public TicketStatus Status { get; set; }
    public string Assignee { get; set; } = "Unassigned";
    public string TimeAgo { get; set; } = "Just now";
}
