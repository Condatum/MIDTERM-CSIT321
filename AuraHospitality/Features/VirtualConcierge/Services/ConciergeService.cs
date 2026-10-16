using AuraHospitality.Features.VirtualConcierge.Models;

namespace AuraHospitality.Features.VirtualConcierge.Services;

public interface IConciergeService
{
    IReadOnlyList<ConciergeMessage> GetHistory();
    ConciergeMessage SendUserMessage(string message);
    event Action? OnMessagesChanged;
}

public class ConciergeService : IConciergeService
{
    private readonly List<ConciergeMessage> _messages = new();

    public event Action? OnMessagesChanged;

    public ConciergeService()
    {
        _messages.Add(new ConciergeMessage(
            "msg-welcome",
            "Celeste (AI Concierge)",
            "Welcome to Aura Luxury Hospitality & Tourism. I am Celeste, your dedicated private digital concierge. How may I elevate your stay or curate your next journey today?",
            DateTime.Now.AddMinutes(-5),
            new List<string>
            {
                "Recommend an unforgettable sunset experience",
                "How do I arrange a private helicopter arrival?",
                "What is the dress code for L’Océan submerged restaurant?",
                "Can you arrange organic champagne in my villa?"
            }
        ));
    }

    public IReadOnlyList<ConciergeMessage> GetHistory() => _messages.AsReadOnly();

    public ConciergeMessage SendUserMessage(string message)
    {
        var userMsg = new ConciergeMessage(Guid.NewGuid().ToString(), "Guest", message, DateTime.Now);
        _messages.Add(userMsg);

        // Generate luxury response
        var lower = message.ToLowerInvariant();
        string reply;
        List<string>? replies = null;

        if (lower.Contains("sunset") || lower.Contains("boat"))
        {
            reply = "For sunset, nothing rivals our private mahogany Riva Aquarama yacht cruise around the Capri Faraglioni rocks or the sunset catamaran dolphin cruise at our Baa Atoll Overwater Sanctuary. Both feature chilled Franciacorta and artisanal antipasti.";
            replies = new List<string> { "Book Riva Yacht charter", "View Overwater Sanctuary", "Order sunset champagne" };
        }
        else if (lower.Contains("helicopter") || lower.Contains("arrival") || lower.Contains("transfer"))
        {
            reply = "We offer direct helicopter helipad transfers for our Zermatt Alpine Chalet, Positano Belvedere Manor, and Baa Atoll resort. Simply share your arrival flight number, and our aviation team coordinates luggage transfer and VIP clearance.";
            replies = new List<string> { "View Zermatt Alpine Chalet", "Contact Chauffeur Dispatch" };
        }
        else if (lower.Contains("dress code") || lower.Contains("dining") || lower.Contains("restaurant"))
        {
            reply = "At L’Océan Submerged Restaurant, the ambiance is 'Resort Elegant' (collared linen shirts, elegant footwear; tailored dresses or evening resort wear). We recommend evening seatings around 19:30 when ambient subaquatic illumination is active.";
            replies = new List<string> { "Reserve table at L’Océan", "View Dining menu" };
        }
        else if (lower.Contains("champagne") || lower.Contains("room service") || lower.Contains("butler"))
        {
            reply = "Splendid choice! Our cellars hold vintage Dom Pérignon, Krug Clos d'Ambonnay, and rare biodynamic grower champagnes. Your island butler will have it chilled in an engraved silver ice bucket with crystal flutes upon your arrival.";
            replies = new List<string> { "Send request to Butler", "View In-Villa Dining" };
        }
        else
        {
            reply = "It is my distinct privilege to assist you. I have logged your preferences with our Chief Concierge. Is there a specific retreat or expedition you would like me to prepare for you?";
            replies = new List<string> { "Explore All Stays", "Curated Expeditions", "View Itinerary Builder" };
        }

        var botMsg = new ConciergeMessage(Guid.NewGuid().ToString(), "Celeste (AI Concierge)", reply, DateTime.Now.AddSeconds(1), replies);
        _messages.Add(botMsg);

        OnMessagesChanged?.Invoke();
        return botMsg;
    }
}
