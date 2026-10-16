using AuraHospitality.Features.TourOperations.Models;
using AuraHospitality.Features.TourOperations.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.TourOperations.Presenters;

public interface ITourOperationsView
{
    void DisplayDispatches(IReadOnlyList<TourDispatchItem> dispatches);
}

public class TourOperationsPresenter
{
    private readonly ITourOperationsService _service;
    private readonly IAppStateService _appState;
    private ITourOperationsView? _view;

    public TourOperationsPresenter(
        ITourOperationsService service,
        IAppStateService appState)
    {
        _service = service;
        _appState = appState;

        _service.OnDispatchesChanged += HandleDispatchesChanged;
    }

    public void AttachView(ITourOperationsView view)
    {
        _view = view;
        RefreshDispatches();
    }

    private void HandleDispatchesChanged()
    {
        RefreshDispatches();
    }

    private void RefreshDispatches()
    {
        _view?.DisplayDispatches(_service.GetAllDispatches());
    }

    public void UpdateDispatchStatus(string dispatchId, string newStatus)
    {
        _service.UpdateStatus(dispatchId, newStatus);
        _appState.PushNotification("Dispatch Status Changed", $"Excursion {dispatchId} is now marked as {newStatus}.", Core.Models.NotificationType.Info);
    }

    public void CheckInGuest(string dispatchId)
    {
        _service.AddGuestToTour(dispatchId);
        _appState.PushNotification("Guest Checked In", $"Participant added to excursion manifest {dispatchId}.", Core.Models.NotificationType.Success);
    }
}
