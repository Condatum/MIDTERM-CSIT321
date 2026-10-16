using AuraHospitality.Features.ItineraryPlanner.Models;

namespace AuraHospitality.Features.ItineraryPlanner.Services;

public interface IItineraryService
{
    ItinerarySchedule GetScheduleForDestination(string destination);
    IReadOnlyList<string> GetAvailableDestinations();
    void AddActivity(int dayNumber, ItineraryActivityItem activity);
    void RemoveActivity(int dayNumber, string activityId);
    event Action? OnScheduleChanged;
}

public class ItineraryService : IItineraryService
{
    private ItinerarySchedule _currentSchedule;

    public event Action? OnScheduleChanged;

    public ItineraryService()
    {
        _currentSchedule = CreateAmalfiSchedule();
    }

    public IReadOnlyList<string> GetAvailableDestinations() => new List<string>
    {
        "Positano & Amalfi Coast, Italy",
        "Zermatt & Matterhorn, Swiss Alps",
        "Serengeti National Park, Tanzania",
        "Kyoto & Arashiyama, Japan"
    };

    public ItinerarySchedule GetScheduleForDestination(string destination)
    {
        _currentSchedule = destination switch
        {
            "Zermatt & Matterhorn, Swiss Alps" => CreateSwissSchedule(),
            "Serengeti National Park, Tanzania" => CreateSerengetiSchedule(),
            "Kyoto & Arashiyama, Japan" => CreateKyotoSchedule(),
            _ => CreateAmalfiSchedule()
        };
        return _currentSchedule;
    }

    public void AddActivity(int dayNumber, ItineraryActivityItem activity)
    {
        var day = _currentSchedule.Days.FirstOrDefault(d => d.DayNumber == dayNumber);
        if (day != null)
        {
            day.Activities.Add(activity);
            OnScheduleChanged?.Invoke();
        }
    }

    public void RemoveActivity(int dayNumber, string activityId)
    {
        var day = _currentSchedule.Days.FirstOrDefault(d => d.DayNumber == dayNumber);
        if (day != null)
        {
            day.Activities.RemoveAll(a => a.Id == activityId);
            OnScheduleChanged?.Invoke();
        }
    }

    private static ItinerarySchedule CreateAmalfiSchedule()
    {
        return new ItinerarySchedule
        {
            Destination = "Positano & Amalfi Coast, Italy",
            Days = new List<ItineraryDayPlan>
            {
                new()
                {
                    DayNumber = 1,
                    Title = "Cliffside Arrival & Sunset Aperitivo",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("act-1", "14:00", "Check-in at Palazzo Belvedere Cliffside Manor", "Positano", 1850m, "Lodging", "Palace"),
                        new("act-2", "17:30", "Private Funicular descent to Seaside Champagne Lounge", "Seaside Cliff", 150m, "Relaxation", "GlassWater"),
                        new("act-3", "20:00", "7-Course Seafood Degustation at Il Ristorante Belvedere", "Cliffside Terrace", 260m, "Dining", "Utensils")
                    }
                },
                new()
                {
                    DayNumber = 2,
                    Title = "Vintage Riva Yacht Charter to Capri & Blue Grotto",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("act-4", "09:30", "Board Mahogany Riva Aquarama at Private Dock", "Positano Harbor", 780m, "Adventure", "Ship"),
                        new("act-5", "13:00", "Cliffside Lunch at Conca del Sogno, Nerano", "Nerano Bay", 220m, "Dining", "Utensils"),
                        new("act-6", "16:00", "Private Swim in secluded Green Grotto with Prosecco", "Capri", 0m, "Relaxation", "Sun")
                    }
                },
                new()
                {
                    DayNumber = 3,
                    Title = "Path of the Gods Hike & Lemon Grove Harvest",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("act-7", "08:30", "Guided Sentiero degli Dei Alpine Sea Cliff Trek", "Bomerano to Nocelle", 180m, "Adventure", "Compass"),
                        new("act-8", "14:00", "Amalfi Sfusato Lemon Picking & Limoncello Atelier", "Ravello Estate", 160m, "Culture", "Sparkles"),
                        new("act-9", "19:30", "Farewell Candlelight Dinner with Live Neapolitan Mandolin", "Positano", 240m, "Dining", "Music")
                    }
                }
            }
        };
    }

    private static ItinerarySchedule CreateSwissSchedule()
    {
        return new ItinerarySchedule
        {
            Destination = "Zermatt & Matterhorn, Swiss Alps",
            Days = new List<ItineraryDayPlan>
            {
                new()
                {
                    DayNumber = 1,
                    Title = "Glacier Express & Alpine Chalet Check-in",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("ch-1", "13:00", "Matterhorn Panorama Glass Chalet Check-In", "Zermatt", 2100m, "Lodging", "Palace"),
                        new("ch-2", "16:30", "Finnish Cedar Sauna & Heated Thermal Plunge", "High Alps", 120m, "Relaxation", "Sparkles"),
                        new("ch-3", "19:30", "Private Swiss Truffle Fondue & Valais Wine Tasting", "Chalet Library", 240m, "Dining", "Utensils")
                    }
                },
                new()
                {
                    DayNumber = 2,
                    Title = "Monte Rosa Heli-Skiing Expedition",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("ch-4", "08:00", "Air Zermatt Helicopter Summit Drop at 4,200m", "Monte Rosa", 1250m, "Adventure", "Compass"),
                        new("ch-5", "13:30", "Alpine Rifugio Gourmet Lunch", "Gornergrat", 160m, "Dining", "Utensils")
                    }
                }
            }
        };
    }

    private static ItinerarySchedule CreateSerengetiSchedule()
    {
        return new ItinerarySchedule
        {
            Destination = "Serengeti National Park, Tanzania",
            Days = new List<ItineraryDayPlan>
            {
                new()
                {
                    DayNumber = 1,
                    Title = "Bush Airstrip Landing & Twilight Boma Fire",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("sg-1", "14:00", "Nomad Acacia Luxury Pavilion Check-In", "Serengeti", 1650m, "Lodging", "Palace"),
                        new("sg-2", "18:00", "Campfire Boma Maasai Storytelling & Sundowner", "Savannah", 140m, "Culture", "Sparkles")
                    }
                },
                new()
                {
                    DayNumber = 2,
                    Title = "Dawn Hot Air Balloon & Big Cat Tracking",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("sg-3", "05:30", "Sky Safari Great Migration Hot Air Balloon Flight", "Mara River", 890m, "Adventure", "Compass"),
                        new("sg-4", "14:30", "Open 4x4 Big Five Game Tracking with Master Naturalist", "Central Serengeti", 250m, "Adventure", "Sun")
                    }
                }
            }
        };
    }

    private static ItinerarySchedule CreateKyotoSchedule()
    {
        return new ItinerarySchedule
        {
            Destination = "Kyoto & Arashiyama, Japan",
            Days = new List<ItineraryDayPlan>
            {
                new()
                {
                    DayNumber = 1,
                    Title = "Bamboo Grove Sanctuary & Onsen Rejuvenation",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("ky-1", "15:00", "Komorebi Bamboo Forest Ryokan Check-in", "Arashiyama", 1380m, "Lodging", "Palace"),
                        new("ky-2", "17:00", "Hinoki Cypress Natural Spring Mineral Bath", "Private Onsen", 0m, "Relaxation", "Sparkles"),
                        new("ky-3", "19:00", "Seasonal 9-Course Kaiseki Dining Banquet", "Ryokan Pavilion", 280m, "Dining", "Utensils")
                    }
                },
                new()
                {
                    DayNumber = 2,
                    Title = "Monk-Led Meditation & Sen Tea Master Ceremony",
                    Activities = new List<ItineraryActivityItem>
                    {
                        new("ky-4", "08:30", "Exclusive Closed-Door Zen Temple Entry & Zazen", "Daitoku-ji", 550m, "Culture", "Compass"),
                        new("ky-5", "14:00", "Uji Ceremonial Matcha Preparation with 15th-Gen Master", "Tea Atelier", 180m, "Culture", "Sparkles")
                    }
                }
            }
        };
    }
}
