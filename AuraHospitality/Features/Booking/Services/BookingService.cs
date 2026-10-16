using AuraHospitality.Features.Booking.Models;

namespace AuraHospitality.Features.Booking.Services;

public interface IBookingService
{
    IReadOnlyList<BookingItem> ActiveBookings { get; }
    BookingReceipt? LatestReceipt { get; }

    event Action? OnBookingsChanged;

    void AddBooking(BookingItem item);
    void RemoveBooking(string id);
    void ClearAllBookings();
    BookingReceipt ProcessCheckout(GuestBookingDetails guestDetails);
    void DismissReceipt();
}

public class BookingService : IBookingService
{
    private readonly List<BookingItem> _activeBookings = new();
    private BookingReceipt? _latestReceipt;

    public IReadOnlyList<BookingItem> ActiveBookings => _activeBookings.AsReadOnly();
    public BookingReceipt? LatestReceipt => _latestReceipt;

    public event Action? OnBookingsChanged;

    public BookingService()
    {
        // Pre-populate with a demo pending reservation for instant delight
        _activeBookings.Add(new BookingItem
        {
            ItemType = BookingItemType.Stay,
            TargetId = "stay-1",
            Title = "Aura Azure Overwater Sanctuary",
            ImageUrl = "https://images.unsplash.com/photo-1514282401047-d79a71a590e8?auto=format&fit=crop&w=600&q=80",
            Destination = "Baa Atoll, Maldives",
            StartDate = DateTime.Today.AddDays(14),
            EndDate = DateTime.Today.AddDays(18),
            Guests = 2,
            UnitPriceUSD = 1450m,
            AddOnsPriceUSD = 250m,
            SelectedAddOns = new List<string> { "Sunset Dolphin Catamaran", "Private Sommelier Wine Tasting" }
        });
    }

    public void AddBooking(BookingItem item)
    {
        _activeBookings.Add(item);
        OnBookingsChanged?.Invoke();
    }

    public void RemoveBooking(string id)
    {
        _activeBookings.RemoveAll(b => b.Id == id);
        OnBookingsChanged?.Invoke();
    }

    public void ClearAllBookings()
    {
        _activeBookings.Clear();
        OnBookingsChanged?.Invoke();
    }

    public BookingReceipt ProcessCheckout(GuestBookingDetails guestDetails)
    {
        decimal subtotal = _activeBookings.Sum(b => b.TotalUSD);
        decimal discount = 0;

        if (!string.IsNullOrWhiteSpace(guestDetails.PromoCode))
        {
            var code = guestDetails.PromoCode.Trim().ToUpperInvariant();
            if (code == "AURA10" || code == "WELCOME10")
            {
                discount = subtotal * 0.10m;
            }
            else if (code == "LUXURY20")
            {
                discount = subtotal * 0.20m;
            }
        }

        var finalTotal = Math.Max(0, subtotal - discount);
        var randomRef = Random.Shared.Next(100000, 999999);
        var confirmationCode = $"AUR-{DateTime.UtcNow:yyMM}-{randomRef}";
        var digitalPass = $"AUR-KEY-{Guid.NewGuid().ToString()[..8].ToUpperInvariant()}";

        var receipt = new BookingReceipt(
            ConfirmationNumber: confirmationCode,
            GuestName: guestDetails.FullName,
            GuestEmail: guestDetails.Email,
            Items: _activeBookings.ToList(),
            SubtotalUSD: subtotal,
            DiscountUSD: discount,
            FinalTotalUSD: finalTotal,
            DigitalPassKey: digitalPass,
            CreatedAt: DateTime.UtcNow
        );

        _latestReceipt = receipt;
        _activeBookings.Clear();
        OnBookingsChanged?.Invoke();

        return receipt;
    }

    public void DismissReceipt()
    {
        _latestReceipt = null;
        OnBookingsChanged?.Invoke();
    }
}
