namespace AuraHospitality.Features.VirtualConcierge.Models;

public record ConciergeMessage(
    string Id,
    string Sender,
    string Content,
    DateTime Timestamp,
    List<string>? QuickReplies = null
);
