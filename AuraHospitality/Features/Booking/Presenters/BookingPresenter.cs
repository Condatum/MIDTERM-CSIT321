using AuraHospitality.Features.Booking.Models;
using AuraHospitality.Features.Booking.Services;
using AuraHospitality.Core.Services;

namespace AuraHospitality.Features.Booking.Presenters;

public interface IBookingView
{
    void DisplayActiveBookings(IReadOnlyList<BookingItem> items);
    void DisplayReceipt(BookingReceipt? receipt);
    void ShowCheckoutModal(bool isVisible);
    void ShowMessage(string message, bool isError = false);
}

public class BookingPresenter
{
    private readonly IBookingService _bookingService;
    private readonly ICurrencyService _currencyService;
    private readonly IAppStateService _appState;
    private IBookingView? _view;

    public GuestBookingDetails GuestDetails { get; private set; } = new();

    public BookingPresenter(
        IBookingService bookingService,
        ICurrencyService currencyService,
        IAppStateService appState)
    {
        _bookingService = bookingService;
        _currencyService = currencyService;
        _appState = appState;

        _bookingService.OnBookingsChanged += HandleBookingsChanged;
    }

    public void AttachView(IBookingView view)
    {
        _view = view;
        RefreshView();
    }

    private void HandleBookingsChanged()
    {
        RefreshView();
    }

    private void RefreshView()
    {
        _view?.DisplayActiveBookings(_bookingService.ActiveBookings);
        _view?.DisplayReceipt(_bookingService.LatestReceipt);
    }

    public void OpenCheckout()
    {
        if (_bookingService.ActiveBookings.Count == 0)
        {
            _appState.PushNotification("Empty Reservation", "Please select a luxury stay or tour expedition first.", Core.Models.NotificationType.Warning);
            return;
        }
        _view?.ShowCheckoutModal(true);
    }

    public void CloseCheckout()
    {
        _view?.ShowCheckoutModal(false);
    }

    public void RemoveItem(string id)
    {
        _bookingService.RemoveBooking(id);
        _appState.PushNotification("Item Removed", "Reservation removed from your trip summary.", Core.Models.NotificationType.Info);
    }

    public void CompleteCheckout()
    {
        if (string.IsNullOrWhiteSpace(GuestDetails.FullName) || string.IsNullOrWhiteSpace(GuestDetails.Email))
        {
            _view?.ShowMessage("Please enter your name and email address.", true);
            return;
        }

        var receipt = _bookingService.ProcessCheckout(GuestDetails);
        _view?.ShowCheckoutModal(false);
        _appState.PushNotification("Reservation Confirmed!", $"Booking reference {receipt.ConfirmationNumber} has been secured.", Core.Models.NotificationType.Success);
        _appState.RequestConfetti();
    }

    public void DismissReceipt()
    {
        _bookingService.DismissReceipt();
    }
}
