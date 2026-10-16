using AuraHospitality.Features.Tours.Models;

namespace AuraHospitality.Features.Tours.Services;

public interface IToursRepository
{
    Task<IReadOnlyList<Tour>> GetAllToursAsync();
    Task<Tour?> GetTourByIdAsync(string id);
    Task<IReadOnlyList<Tour>> FilterToursAsync(TourFilterCriteria criteria);
    Task<IReadOnlyList<string>> GetCategoriesAsync();
}

public class ToursRepository : IToursRepository
{
    private readonly List<Tour> _tours = new()
    {
        new Tour(
            "tour-1",
            "Serengeti Great Migration Sky & Bush Expedition",
            "Serengeti, Tanzania",
            "Wildlife Safaris",
            "Signature Experience",
            890m,
            "Full Day (10 Hours)",
            5.0,
            89,
            "Easy / Moderate",
            "Max 6 guests",
            "https://images.unsplash.com/photo-1516426122078-c23e76319801?auto=format&fit=crop&w=1000&q=80",
            "Drift silently in a hot air balloon over millions of wildebeest and zebras crossing the Mara River at dawn. Follow with a champagne bush breakfast and private 4x4 big cat tracking with our master Maasai tracker.",
            new List<string>
            {
                "Dawn hot air balloon ascent with 360-degree aerial views",
                "Five-star champagne breakfast served beneath an acacia tree in the savannah",
                "Big Five (lion, leopard, rhino, elephant, buffalo) guided safari tracking",
                "Professional telephoto lens wildlife photography mentoring",
                "All conservation fees and park entry passes included"
            },
            new TourGuide("Joseph Ole Saitoti", "Senior Maasai Naturalist & Field Expert (18 yrs experience)", "https://images.unsplash.com/photo-1534528741775-53994a69daeb?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Hot Air Balloon Flight", "Champagne Bush Banquet", "4x4 Game Drive", "Photography Kit", "Park Permits" }
        ),
        new Tour(
            "tour-2",
            "Bioluminescent Night Dive & Manta Ray Sanctuary",
            "Baa Atoll, Maldives",
            "Marine Expeditions",
            "Underwater Wonder",
            420m,
            "4 Hours (Night)",
            4.98,
            114,
            "Moderate",
            "Max 4 guests",
            "https://images.unsplash.com/photo-1544551763-46a013bb70d5?auto=format&fit=crop&w=1000&q=80",
            "Submerge into a world of celestial light. Swim alongside gentle giant Manta Rays feeding amidst millions of glowing bioluminescent phytoplankton, accompanied by our marine biologist.",
            new List<string>
            {
                "Night-time diving / guided snorkeling in protected Hanifaru Bay",
                "Witness glowing phytoplankton illuminating the waters with every movement",
                "Encounter manta rays and harmless nurse sharks in their natural feeding dance",
                "Ultra-violet fluorescent dive torches provided",
                "4K underwater video documentary of your dive included"
            },
            new TourGuide("Dr. Elena Rostova", "Resident Marine Biologist & PADI Master Scuba Diver", "https://images.unsplash.com/photo-1580489944761-15a19d654956?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Scuba/Snorkel Gear", "Marine Biologist Briefing", "Fluo Torches", "Boat Charter", "4K Video File" }
        ),
        new Tour(
            "tour-3",
            "Kyoto Secret Temples, Zen Masters & Tea Rite",
            "Kyoto, Japan",
            "Cultural Heritage",
            "Exclusive Access",
            550m,
            "6 Hours",
            4.99,
            142,
            "Gentle",
            "Private (1-4 guests)",
            "https://images.unsplash.com/photo-1503899036084-c55cdd92da26?auto=format&fit=crop&w=1000&q=80",
            "Gain behind-closed-doors entry to an ancient 800-year-old sub-temple closed to the general public. Engage in private meditation led by the Head Abbot, followed by an authentic Sen-family tea ceremony.",
            new List<string>
            {
                "Private entry before and after public visiting hours",
                "Direct guidance in Zazen meditation by the 24th generation Zen master",
                "Handcrafted Uji ceremonial matcha prepared according to centuries-old ritual",
                "Exclusive stroll through private moss gardens and hidden cedar courtyards",
                "Kaiseki bento lunch box prepared by a three-star culinary atelier"
            },
            new TourGuide("Kenjiro Takahashi", "Kyoto Cultural Historian & Licensed Tea Master", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Private Temple Entry", "Zen Master Session", "Tea Master Experience", "Kaiseki Lunch", "Private Sedan" }
        ),
        new Tour(
            "tour-4",
            "Amalfi Vintage Riva Yacht & Hidden Grottos",
            "Positano & Capri, Italy",
            "Coastal Expeditions",
            "La Dolce Vita",
            780m,
            "7 Hours",
            4.97,
            167,
            "Relaxed",
            "Private (Up to 6)",
            "https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1000&q=80",
            "Step aboard a pristine handcrafted mahogany Riva Aquarama yacht. Cruise past dramatic cliffs of Positano to the Faraglioni rocks of Capri, swimming in emerald sea grottos with iced Prosecco and fresh antipasti.",
            new List<string>
            {
                "Charter of an authentic classic Riva yacht with professional captain",
                "Swim and snorkel in secluded sea caverns inaccessible from land",
                "Cruise around Capri, stopping at the White and Green Grottos",
                "Reserved seaside lunch table at famous Conca del Sogno restaurant",
                "Endless chilled Franciacorta, local buffalo mozzarella, and fresh figs on board"
            },
            new TourGuide("Capitano Marco Esposito", "Third-Generation Amalfi Coast Captain & Sailor", "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Riva Yacht Charter", "Fuel & Skipper", "Champagne & Antipasti", "Snorkel Equipment", "Towels & Sun Care" }
        ),
        new Tour(
            "tour-5",
            "Matterhorn Heli-Ski & High Glacier Traverse",
            "Zermatt, Switzerland",
            "Alpine Adventures",
            "Extreme Luxury",
            1250m,
            "Full Day (8 Hours)",
            5.0,
            62,
            "Advanced",
            "Max 4 skiers",
            "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?auto=format&fit=crop&w=1000&q=80",
            "Helicopter flight to the pristine Monte Rosa glacier summit at 4,200m altitude. Carve first tracks down endless untracked powdery couloirs with UIAGM certified mountain guides.",
            new List<string>
            {
                "Air Zermatt private helicopter glacier landing",
                "Over 2,500 vertical meters of untracked virgin powder descent",
                "UIAGM certified mountain guide with satellite avalanche telemetry",
                "Gourmet hot lunch at a secluded high-alpine mountain rifugio",
                "GoPro telemetry helmet footage and drone chase footage"
            },
            new TourGuide("Beatrix von Bergen", "UIAGM High Mountain & Heli-Ski Guide", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Helicopter Drop-off", "UIAGM Guide", "ABS Avalanche Airbag", "Gourmet Lunch", "Ski Passes" }
        ),
        new Tour(
            "tour-6",
            "Patagonia Perito Moreno Ice Trek & Zodiac Safari",
            "Torres del Paine & El Calafate",
            "Glacier Expeditions",
            "Wild Frontier",
            640m,
            "8 Hours",
            4.96,
            88,
            "Moderate / Challenging",
            "Max 8 guests",
            "https://images.unsplash.com/photo-1527004013197-933c4bb611b3?auto=format&fit=crop&w=1000&q=80",
            "Strap on steel crampons and walk across deep blue ice crevasses, frozen lagoons, and glacial caves of the living glacier. Conclude with single-malt Patagonian whisky served over million-year-old glacier ice.",
            new List<string>
            {
                "High-speed expedition Zodiac navigation along sheer 60-meter ice walls",
                "3-hour guided ice trek with professional crampons and ice axes",
                "Whisky on pure, crystalline ancient glacier ice",
                "Scenic picnic lunch overlooking the thundering ice calving events",
                "Round-trip private Mercedes Sprinter transfers with naturalist"
            },
            new TourGuide("Mateo Cárdenas", "Glaciologist & Senior Andean Trek Leader", "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?auto=format&fit=crop&w=200&q=80"),
            new List<string> { "Ice Crampons & Safety Gear", "Zodiac Boat Safari", "Glaciology Guide", "Lunch & Whisky", "Park Pass" }
        )
    };

    public Task<IReadOnlyList<Tour>> GetAllToursAsync()
    {
        return Task.FromResult<IReadOnlyList<Tour>>(_tours);
    }

    public Task<Tour?> GetTourByIdAsync(string id)
    {
        var tour = _tours.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(tour);
    }

    public Task<IReadOnlyList<Tour>> FilterToursAsync(TourFilterCriteria criteria)
    {
        var query = _tours.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(criteria.Category) && criteria.Category != "All")
        {
            query = query.Where(t => t.Category.Equals(criteria.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(criteria.SearchQuery))
        {
            var term = criteria.SearchQuery.Trim().ToLowerInvariant();
            query = query.Where(t => t.Title.ToLowerInvariant().Contains(term) ||
                                     t.Destination.ToLowerInvariant().Contains(term) ||
                                     t.Description.ToLowerInvariant().Contains(term));
        }

        if (criteria.MaxPrice.HasValue)
        {
            query = query.Where(t => t.PricePerPerson <= criteria.MaxPrice.Value);
        }

        return Task.FromResult<IReadOnlyList<Tour>>(query.ToList());
    }

    public Task<IReadOnlyList<string>> GetCategoriesAsync()
    {
        var categories = new List<string> { "All" };
        categories.AddRange(_tours.Select(t => t.Category).Distinct());
        return Task.FromResult<IReadOnlyList<string>>(categories);
    }
}
