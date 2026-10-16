using AuraHospitality.Features.DiningAndWellness.Models;
using AuraHospitality.Features.DiningAndWellness.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.DiningAndWellness.Presenters;

public interface IDiningWellnessView
{
    void DisplayItems(IReadOnlyList<CulinaryWellnessItem> items);
    void ShowReservationModal(CulinaryWellnessItem? item);
}

public class DiningWellnessPresenter
{
    private readonly IDiningWellnessService _service;
    private readonly IAppStateService _appState;
    private IDiningWellnessView? _view;

    public DiningWellnessReservationRequest CurrentRequest { get; private set; } = new();

    public DiningWellnessPresenter(
        IDiningWellnessService service,
        IAppStateService appState)
    {
        _service = service;
        _appState = appState;
    }

    public void AttachView(IDiningWellnessView view)
    {
        _view = view;
        _view.DisplayItems(_service.GetAll());
    }

    public void OpenReservation(CulinaryWellnessItem item)
    {
        CurrentRequest = new DiningWellnessReservationRequest
        {
            ExperienceId = item.Id,
            ExperienceName = item.Name
        };
        _view?.ShowReservationModal(item);
    }

    public void CloseReservation()
    {
        _view?.ShowReservationModal(null);
    }

    public void ConfirmReservation()
    {
        _service.BookReservation(CurrentRequest);
        _view?.ShowReservationModal(null);
        _appState.PushNotification("Reservation Secured", $"Table/Appointment confirmed at {CurrentRequest.ExperienceName} for {CurrentRequest.Guests} guests on {CurrentRequest.Date:MMM dd} at {CurrentRequest.TimeSlot}.", Core.Models.NotificationType.Success);
        _appState.RequestConfetti();
    }
}
