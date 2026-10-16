using AuraHospitality.Components;
using AuraHospitality.Core.Services;
using AuraHospitality.Features.Stays.Services;
using AuraHospitality.Features.Stays.Presenters;
using AuraHospitality.Features.Tours.Services;
using AuraHospitality.Features.Tours.Presenters;
using AuraHospitality.Features.Booking.Services;
using AuraHospitality.Features.Booking.Presenters;
using AuraHospitality.Features.PropertyManagement.Services;
using AuraHospitality.Features.PropertyManagement.Presenters;
using AuraHospitality.Features.HousekeepingOperations.Services;
using AuraHospitality.Features.HousekeepingOperations.Presenters;
using AuraHospitality.Features.TourOperations.Services;
using AuraHospitality.Features.TourOperations.Presenters;
using AuraHospitality.Features.ItineraryPlanner.Services;
using AuraHospitality.Features.ItineraryPlanner.Presenters;
using AuraHospitality.Features.DiningAndWellness.Services;
using AuraHospitality.Features.DiningAndWellness.Presenters;
using AuraHospitality.Features.VirtualConcierge.Services;
using AuraHospitality.Features.VirtualConcierge.Presenters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Core Services
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IAppStateService, AppStateService>();

// Feature Slices: Repositories & Services
builder.Services.AddScoped<IStaysRepository, StaysRepository>();
builder.Services.AddScoped<IToursRepository, ToursRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomRackService, RoomRackService>();
builder.Services.AddScoped<IHousekeepingService, HousekeepingService>();
builder.Services.AddScoped<ITourOperationsService, TourOperationsService>();
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<IDiningWellnessService, DiningWellnessService>();
builder.Services.AddScoped<IConciergeService, ConciergeService>();

// Feature Slices: MVP Presenters
builder.Services.AddTransient<StaysPresenter>();
builder.Services.AddTransient<ToursPresenter>();
builder.Services.AddTransient<BookingPresenter>();
builder.Services.AddTransient<RoomRackPresenter>();
builder.Services.AddTransient<HousekeepingPresenter>();
builder.Services.AddTransient<TourOperationsPresenter>();
builder.Services.AddTransient<ItineraryPresenter>();
builder.Services.AddTransient<DiningWellnessPresenter>();
builder.Services.AddTransient<ConciergePresenter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
