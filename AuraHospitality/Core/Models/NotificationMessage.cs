namespace AuraHospitality.Core.Models;

public enum NotificationType
{
    Success,
    Info,
    Warning,
    Error
}

public record NotificationMessage(
    string Id,
    string Title,
    string Message,
    NotificationType Type = NotificationType.Info,
    DateTime Timestamp = default
)
{
    public DateTime Timestamp { get; init; } = Timestamp == default ? DateTime.Now : Timestamp;
}
