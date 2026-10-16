using AuraHospitality.Features.ItineraryPlanner.Models;
using AuraHospitality.Features.ItineraryPlanner.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.ItineraryPlanner.Presenters;

public interface IItineraryView
{
    void DisplaySchedule(ItinerarySchedule schedule);
    void DisplayDestinations(IReadOnlyList<string> destinations);
}

public class ItineraryPresenter
{
    private readonly IItineraryService _service;
    private readonly ICurrencyService _currencyService;
    private readonly IAppStateService _appState;
    private IItineraryView? _view;

    public string CurrentDestination { get; private set; } = "Positano & Amalfi Coast, Italy";

    public ItineraryPresenter(
        IItineraryService service,
        ICurrencyService currencyService,
        IAppStateService appState)
    {
        _service = service;
        _currencyService = currencyService;
        _appState = appState;

        _service.OnScheduleChanged += HandleScheduleChanged;
    }

    public void AttachView(IItineraryView view)
    {
        _view = view;
        _view.DisplayDestinations(_service.GetAvailableDestinations());
        RefreshSchedule();
    }

    private void HandleScheduleChanged()
    {
        RefreshSchedule();
    }

    private void RefreshSchedule()
    {
        var schedule = _service.GetScheduleForDestination(CurrentDestination);
        _view?.DisplaySchedule(schedule);
    }

    public void SelectDestination(string destination)
    {
        CurrentDestination = destination;
        RefreshSchedule();
        _appState.PushNotification("Destination Loaded", $"Curated vacation itinerary updated for {destination}.", Core.Models.NotificationType.Info);
    }

    public void RemoveActivity(int dayNumber, string activityId)
    {
        _service.RemoveActivity(dayNumber, activityId);
        _appState.PushNotification("Activity Removed", "Itinerary schedule updated.", Core.Models.NotificationType.Info);
    }
}
