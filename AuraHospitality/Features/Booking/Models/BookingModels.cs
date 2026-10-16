namespace AuraHospitality.Features.Booking.Models;

public enum BookingItemType
{
    Stay,
    Tour,
    Dining,
    Spa
}

public class BookingItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BookingItemType ItemType { get; set; }
    public string TargetId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Today.AddDays(7);
    public DateTime? EndDate { get; set; } = DateTime.Today.AddDays(11);
    public int Guests { get; set; } = 2;
    public decimal UnitPriceUSD { get; set; }
    public decimal AddOnsPriceUSD { get; set; }
    public List<string> SelectedAddOns { get; set; } = new();

    public int TotalNights => EndDate.HasValue ? Math.Max(1, (EndDate.Value - StartDate).Days) : 1;

    public decimal TotalUSD
    {
        get
        {
            if (ItemType == BookingItemType.Stay)
            {
                return (UnitPriceUSD * TotalNights) + AddOnsPriceUSD;
            }
            return (UnitPriceUSD * Guests) + AddOnsPriceUSD;
        }
    }
}

public class GuestBookingDetails
{
    public string FullName { get; set; } = "Alexandra Vance";
    public string Email { get; set; } = "alexandra.vance@celestia.luxury";
    public string Phone { get; set; } = "+1 (555) 234-8900";
    public string Country { get; set; } = "United States";
    public string SpecialRequests { get; set; } = "Champagne upon arrival, allergen-free bedding.";
    public string PromoCode { get; set; } = string.Empty;
}

public record BookingReceipt(
    string ConfirmationNumber,
    string GuestName,
    string GuestEmail,
    IReadOnlyList<BookingItem> Items,
    decimal SubtotalUSD,
    decimal DiscountUSD,
    decimal FinalTotalUSD,
    string DigitalPassKey,
    DateTime CreatedAt
);
