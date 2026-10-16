using AuraHospitality.Features.Stays.Models;

namespace AuraHospitality.Features.Stays.Services;

public interface IStaysRepository
{
    Task<IReadOnlyList<Stay>> GetAllStaysAsync();
    Task<Stay?> GetStayByIdAsync(string id);
    Task<IReadOnlyList<Stay>> FilterStaysAsync(StayFilterCriteria criteria);
    Task<IReadOnlyList<string>> GetCategoriesAsync();
}

public class StaysRepository : IStaysRepository
{
    private readonly List<Stay> _stays = new()
    {
        new Stay(
            "stay-1",
            "Aura Azure Overwater Sanctuary",
            "Baa Atoll, Maldives",
            "Overwater Villa",
            "Private Island",
            1450m,
            4.98,
            142,
            new List<string>
            {
                "https://images.unsplash.com/photo-1514282401047-d79a71a590e8?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1571896349842-33c89424de2d?auto=format&fit=crop&w=1200&q=80"
            },
            "Suspended above turquoise crystalline lagoons in a UNESCO Biosphere Reserve. Features direct reef access, private freshwater infinity pool, catamaran hammock nets, glass floor viewing portals, and 24-hour dedicated butler service.",
            2, 2, 4, 280,
            new List<string>
            {
                "Direct Lagoon Access", "Private Freshwater Infinity Pool", "24/7 Dedicated Island Butler",
                "Overwater Sun Deck & Hammocks", "Outdoor Rainforest Shower", "Complimentary Sunset Dolphin Cruise",
                "Subaquatic Wine Cellar Access", "High-Speed Satellite Wi-Fi"
            },
            new List<string> { "Eco-Certified 100% Solar", "Michelin Chef On-Demand", "Helipad Arrival" }
        ),
        new Stay(
            "stay-2",
            "Palazzo Belvedere Cliffside Manor",
            "Positano, Amalfi Coast, Italy",
            "Oceanfront Villas",
            "Historical Luxury",
            1850m,
            4.96,
            98,
            new List<string>
            {
                "https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b?auto=format&fit=crop&w=1200&q=80"
            },
            "A 17th-century lemon-grove sanctuary carved into the sheer limestone cliffs above Positano. Panoramic views of the Tyrrhenian Sea, ancient vaulted ceilings, antique terracotta floors, and private funicular access to the sea.",
            3, 3, 6, 350,
            new List<string>
            {
                "Heated Cliffside Plunge Pool", "Private Funicular to Beach Club", "Organic Lemon Grove Terrace",
                "Sommelier Wine Tasting Lounge", "Private Riva Yacht Mooring", "Dedicated Chauffeur & S-Class",
                "Limonaia Outdoor Dining Area", "Wood-Fired Neapolitan Pizza Oven"
            },
            new List<string> { "UNESCO Cultural Heritage", "Private Speedboat Included", "Michelin Star Dining" }
        ),
        new Stay(
            "stay-3",
            "Matterhorn Panorama Glass Chalet",
            "Zermatt, Swiss Alps",
            "Alpine Chalet",
            "Mountain Sanctuary",
            2100m,
            4.99,
            86,
            new List<string>
            {
                "https://images.unsplash.com/photo-1502784444187-359ac186c5bb?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?auto=format&fit=crop&w=1200&q=80"
            },
            "Perched in the high alpine peaks facing the iconic Matterhorn pyramid. Tri-level architectural masterpiece with floor-to-ceiling heated thermal glass, private cedar sauna, outdoor hot tub surrounded by fresh powder, and ski-in/ski-out access.",
            4, 4, 8, 420,
            new List<string>
            {
                "Direct Ski-in / Ski-out Access", "Matterhorn View Geothermal Hot Tub", "Finnish Cedar Sauna & Cryo Plunge",
                "Fireplace Library & Whiskey Bar", "Ski Equipment Concierge", "Private Swiss Fondue & Raclette Chef",
                "Heated Boot Room", "Air Purification & Oxygen Enrichment"
            },
            new List<string> { "Zero Carbon Geothermal", "Private Ski Instructor", "Helicopter Transfer" }
        ),
        new Stay(
            "stay-4",
            "Serengeti Nomad Acacia Pavilion",
            "Serengeti National Park, Tanzania",
            "Safari Pavilions",
            "Wildlife Immersion",
            1650m,
            4.97,
            112,
            new List<string>
            {
                "https://images.unsplash.com/photo-1547471080-7cc2caa01a7e?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1516426122078-c23e76319801?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e?auto=format&fit=crop&w=1200&q=80"
            },
            "Ultra-luxurious canvas and mahogany pavilion situated along the Great Migration migratory corridor. Open-air star-gazing deck, copper soaking tubs with endless savannah views, campfire boma storytelling, and custom open-roof 4x4 game drives.",
            2, 2, 4, 220,
            new List<string>
            {
                "Private 4x4 Game Vehicle & Maasai Tracker", "Open-Air Stargazing Observation Deck", "Hand-Hammered Copper Soaking Tub",
                "Savannah Sunset Boma Fireplace", "Solar-Powered Silent Energy", "Bush Picnic & Sundowner Experience",
                "Field Wildlife Photography Gear", "Artisanal Bush Bar"
            },
            new List<string> { "Wildlife Conservation Partner", "Maasai Cultural Council", "Bush Plane Airstrip" }
        ),
        new Stay(
            "stay-5",
            "Komorebi Bamboo Forest Ryokan",
            "Arashiyama, Kyoto, Japan",
            "Cultural Heritage",
            "Zen Sanctuary",
            1380m,
            4.99,
            165,
            new List<string>
            {
                "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1503899036084-c55cdd92da26?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1528164344705-475426879c0d?auto=format&fit=crop&w=1200&q=80"
            },
            "Traditional sukiya-zukuri architecture nestled within whispering bamboo groves along the Oi River. Features natural thermal onsen baths fed by mountain mineral springs, authentic tatami mat tea rooms, and Kaiseki multi-course dining.",
            2, 2, 4, 190,
            new List<string>
            {
                "Private Hinoki Cypress Hot Spring Onsen", "Daily 9-Course Seasonal Kaiseki Banquet", "Private Chado Japanese Tea Ceremony",
                "Traditional Zen Rock Meditation Garden", "Handwoven Silk Yukata Robes", "Shakuhachi Flute Sunset Recital",
                "Curated Green Tea & Sake Cellar", "Exclusive Monk-Led Morning Temple Tour"
            },
            new List<string> { "Ancient Natural Hot Spring", "Kaiseki Master Chef", "Ryokan Hospitality" }
        ),
        new Stay(
            "stay-6",
            "Caldera Horizon Cave Palatial Villa",
            "Oia, Santorini, Greece",
            "Oceanfront Villas",
            "Volcanic Caldera",
            1720m,
            4.95,
            130,
            new List<string>
            {
                "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1200&q=80"
            },
            "Sculpted organically out of volcanic rock 300 meters above the Aegean Sea. An expansive terrace with an infinity hydro-pool jutting out over the abyss, world-famous golden sunset panoramas, and Aegean culinary service.",
            2, 2, 5, 260,
            new List<string>
            {
                "Caldera-Edge Heated Infinity Pool", "Indoor Volcanic Rock Steam Cave", "Sunken Outdoor Fire Lounge",
                "Private Sunset Champagne Tasting", "Helicopter Landing Pad Access", "Assyrtiko Wine Cellar",
                "Dedicated Porter & Concierge", "Daily Mediterranean Breakfast on Terrace"
            },
            new List<string> { "Unobstructed Sunset Views", "Private Yacht Excursion", "Cave Spa" }
        ),
        new Stay(
            "stay-7",
            "Uluwatu Ocean Cliff Estate",
            "Uluwatu, Bali, Indonesia",
            "Oceanfront Villas",
            "Tropical Haven",
            1290m,
            4.97,
            148,
            new List<string>
            {
                "https://images.unsplash.com/photo-1537996194471-e657df975ab4?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=1200&q=80"
            },
            "Perched 150 meters atop dramatic limestone sea cliffs overlooking world-class surf breaks. Features cascading freshwater swimming pools, traditional Balinese teak pavilions, open-air living pavilions, and holistic sound healing retreats.",
            3, 3, 6, 380,
            new List<string>
            {
                "Dual-Tier Cliffside Infinity Pool", "Daily Balinese Spa & Flower Bath", "Private Yoga & Meditation Shala",
                "Private Surf Guide & Board Caddy", "Balinese Organic Farm-to-Table Chef", "Cliff-Edge Sunset Cocktail Lounge",
                "Traditional Gamelan Evening Blessing", "Private Luxury Van & Driver"
            },
            new List<string> { "Holistic Wellness Center", "Direct Cliff Access", "Sustainable Architecture" }
        ),
        new Stay(
            "stay-8",
            "Glaciares Fjords Eco-Lodge",
            "Torres del Paine, Patagonia, Chile",
            "Alpine Chalet",
            "Remote Wilderness",
            1950m,
            4.99,
            77,
            new List<string>
            {
                "https://images.unsplash.com/photo-1527004013197-933c4bb611b3?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1502784444187-359ac186c5bb?auto=format&fit=crop&w=1200&q=80"
            },
            "An architectural marvel on the edge of Lake Pehoé facing the granite horns of Torres del Paine. Passive-heated wood and slate design, private wood-fired hot tubs overlooking glaciers, and expedition naturalists at your disposal.",
            2, 2, 4, 240,
            new List<string>
            {
                "Lake Pehoé & Glacier Frontage", "Patagonian Lenga Wood-Fired Hot Tub", "Private Mountain Guide & Naturalist",
                "Traditional Asado Barbecue Feast", "Equestrian Ranch & Gaucho Treks", "Stargazing Observatory Telescope",
                "Geothermal Floor Heating", "High-Latitude Expedition Gear Rental"
            },
            new List<string> { "100% Carbon Neutral", "Biosphere Reserve", "All-Inclusive Expeditions" }
        )
    };

    public Task<IReadOnlyList<Stay>> GetAllStaysAsync()
    {
        return Task.FromResult<IReadOnlyList<Stay>>(_stays);
    }

    public Task<Stay?> GetStayByIdAsync(string id)
    {
        var stay = _stays.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(stay);
    }

    public Task<IReadOnlyList<Stay>> FilterStaysAsync(StayFilterCriteria criteria)
    {
        var query = _stays.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(criteria.Category) && criteria.Category != "All")
        {
            query = query.Where(s => s.Category.Equals(criteria.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(criteria.SearchQuery))
        {
            var term = criteria.SearchQuery.Trim().ToLowerInvariant();
            query = query.Where(s => s.Name.ToLowerInvariant().Contains(term) ||
                                     s.Destination.ToLowerInvariant().Contains(term) ||
                                     s.Tag.ToLowerInvariant().Contains(term) ||
                                     s.Description.ToLowerInvariant().Contains(term));
        }

        if (criteria.MaxPrice.HasValue)
        {
            query = query.Where(s => s.PricePerNight <= criteria.MaxPrice.Value);
        }

        if (criteria.MinRating > 0)
        {
            query = query.Where(s => s.Rating >= criteria.MinRating);
        }

        return Task.FromResult<IReadOnlyList<Stay>>(query.ToList());
    }

    public Task<IReadOnlyList<string>> GetCategoriesAsync()
    {
        var categories = new List<string> { "All" };
        categories.AddRange(_stays.Select(s => s.Category).Distinct());
        return Task.FromResult<IReadOnlyList<string>>(categories);
    }
}
