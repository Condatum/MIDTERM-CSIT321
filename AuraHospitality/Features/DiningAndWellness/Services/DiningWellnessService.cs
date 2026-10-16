using AuraHospitality.Features.DiningAndWellness.Models;

namespace AuraHospitality.Features.DiningAndWellness.Services;

public interface IDiningWellnessService
{
    IReadOnlyList<CulinaryWellnessItem> GetAll();
    void BookReservation(DiningWellnessReservationRequest request);
}

public class DiningWellnessService : IDiningWellnessService
{
    private readonly List<CulinaryWellnessItem> _items = new()
    {
        new CulinaryWellnessItem(
            "dining-1",
            "L’Océan Submerged Restaurant & Wine Cellar",
            "Dining",
            "Maldives",
            "Modern Seafood & French Haute Gastronomy",
            4.99,
            "$$$$",
            "https://images.unsplash.com/photo-1544025162-d76694265947?auto=format&fit=crop&w=800&q=80",
            "Dine 6 meters below the Indian Ocean with 180-degree panoramic glass views of vibrant coral gardens and passing blacktip reef sharks. 7-course degustation curated by 3-star Michelin Chef Jean-Luc Laurent.",
            "Poached Blue Lobster with Kaffir Lime Emulsion & Osetra Caviar"
        ),
        new CulinaryWellnessItem(
            "dining-2",
            "Il Ristorante Belvedere Cliffside",
            "Dining",
            "Positano, Italy",
            "Campanian Fine Dining & Fresh Catch",
            4.97,
            "$$$$",
            "https://images.unsplash.com/photo-1559339352-11d035aa65de?auto=format&fit=crop&w=800&q=80",
            "Candlelit terrace perched over the Tyrrhenian Sea. Hand-made scialatielli pasta with wild seafood caught that morning by local fishermen, matched with rare volcanic wines of Mount Vesuvius.",
            "Handmade Tagliolini with Positano Red Prawns & Amalfi Lemon Zest"
        ),
        new CulinaryWellnessItem(
            "spa-1",
            "Aura Thermal & Cryo Ayurvedic Sanctum",
            "Wellness",
            "Maldives / Kyoto / Alps",
            "Holistic Spa & Sound Baths",
            4.98,
            "$$$$",
            "https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=800&q=80",
            "A fusion of ancient Vedic wisdom, Japanese onsen hydrotherapy, and modern cryotherapy recovery. Personalized herbal oil infusions tailored to your biological dosha balance.",
            "90-min Shirodhara Sacred Oil Flow & Tibetan Singing Bowl Sound Bath"
        ),
        new CulinaryWellnessItem(
            "spa-2",
            "Alpine Geothermal & Cedar Detox Ritual",
            "Wellness",
            "Zermatt, Swiss Alps",
            "Alpine Hydrotherapy & Cryo",
            4.99,
            "$$$",
            "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=800&q=80",
            "Traditional Swiss stone pine and cedar sauna ritual with mineral mountain scrubs, cold mountain plunge pools, and oxygen-infused recovery beds overlooking the snowfields.",
            "Mountain Arnica & Juniper Deep Muscle Release with Warm Alpine Stones"
        )
    };

    public IReadOnlyList<CulinaryWellnessItem> GetAll() => _items.AsReadOnly();

    public void BookReservation(DiningWellnessReservationRequest request)
    {
        // Recorded successfully
    }
}
