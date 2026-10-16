# AURA — Global Luxury Hospitality & Tourism Platform

A comprehensive, production-grade **Hospitality Management & Tourism Web Platform** built with **C#**, **ASP.NET Core 8 Blazor**, **Tailwind CSS**, strictly adhering to **Model-View-Presenter (MVP)** pattern and **Vertical Slice Architecture**.

---

## 🏛️ Architecture Overview

### 1. Model-View-Presenter (MVP) Pattern
Each feature slice decouples UI representation from domain logic:
- **Model**: Domain entities, calculation engines, and state records (e.g., `Stay`, `Tour`, `BookingItem`, `RoomRackItem`, `HousekeepingTicket`, `ItinerarySchedule`).
- **View (`IView`)**: Strongly-typed interfaces (`IStaysView`, `IToursView`, `IBookingView`, `IRoomRackView`, `IHousekeepingView`, `ITourOperationsView`, `IItineraryView`, `IConciergeView`) implemented by Razor Components. Views remain dumb, focused solely on presentation and capturing UI events.
- **Presenter**: Mediates between Services/Repositories and Views. Responsible for input validation, dynamic currency transformations, promo calculations, filtering, and commanding the View to update.

### 2. Vertical Slice Architecture
Instead of traditional horizontal layers (controllers, services, views separated globally), code is organized into self-contained feature slices:
```
AuraHospitality/
├── Core/
│   ├── Models/               # Currency, NotificationMessage, ViewMode
│   └── Services/             # AppStateService, CurrencyService
│
├── Features/
│   ├── Stays/                # Luxury Villas & Sanctuaries
│   │   ├── Models/           # Stay.cs, StayFilterCriteria.cs
│   │   ├── Services/         # IStaysRepository.cs, StaysRepository.cs
│   │   ├── Presenters/       # IStaysView.cs, StaysPresenter.cs
│   │   └── Components/       # StaysSection.razor, StayDetailModal.razor
│   │
│   ├── Tours/                # Curated Global Tourism Expeditions
│   │   ├── Models/           # Tour.cs, TourFilterCriteria.cs, TourGuide.cs
│   │   ├── Services/         # IToursRepository.cs, ToursRepository.cs
│   │   ├── Presenters/       # IToursView.cs, ToursPresenter.cs
│   │   └── Components/       # ToursSection.razor, TourDetailModal.razor
│   │
│   ├── Booking/              # Reservation Engine & Digital Key Pass
│   │   ├── Models/           # BookingItem.cs, GuestBookingDetails.cs, BookingReceipt.cs
│   │   ├── Services/         # IBookingService.cs, BookingService.cs
│   │   ├── Presenters/       # IBookingView.cs, BookingPresenter.cs
│   │   └── Components/       # ActiveTripsDrawer.razor, BookingCheckoutModal.razor, ConfirmationReceiptModal.razor
│   │
│   ├── PropertyManagement/   # PMS Operations, Room Rack & Folios
│   │   ├── Models/           # RoomRackItem.cs, RoomStatusType.cs, FolioCharge.cs
│   │   ├── Services/         # IRoomRackService.cs, RoomRackService.cs
│   │   ├── Presenters/       # IRoomRackView.cs, RoomRackPresenter.cs
│   │   └── Components/       # RoomRackDashboard.razor, RoomDetailModal.razor
│   │
│   ├── HousekeepingOperations/ # Housekeeping & Butler Dispatch Board
│   │   ├── Models/           # HousekeepingTicket.cs, TicketEnums.cs
│   │   ├── Services/         # IHousekeepingService.cs, HousekeepingService.cs
│   │   ├── Presenters/       # IHousekeepingView.cs, HousekeepingPresenter.cs
│   │   └── Components/       # HousekeepingBoard.razor, CreateTicketModal.razor
│   │
│   ├── TourOperations/       # Field Tourism & Excursion Manifest Control
│   │   ├── Models/           # TourDispatchItem.cs
│   │   ├── Services/         # ITourOperationsService.cs, TourOperationsService.cs
│   │   ├── Presenters/       # ITourOperationsView.cs, TourOperationsPresenter.cs
│   │   └── Components/       # TourOperationsBoard.razor
│   │
│   ├── ItineraryPlanner/     # Interactive Custom Vacation Builder
│   │   ├── Models/           # ItinerarySchedule.cs, ItineraryDayPlan.cs, ItineraryActivityItem.cs
│   │   ├── Services/         # IItineraryService.cs, ItineraryService.cs
│   │   ├── Presenters/       # IItineraryView.cs, ItineraryPresenter.cs
│   │   └── Components/       # ItineraryPlannerView.razor
│   │
│   ├── DiningAndWellness/    # Michelin Dining & Ayurvedic Spas
│   │   ├── Models/           # CulinaryWellnessItem.cs, DiningWellnessReservationRequest.cs
│   │   ├── Services/         # IDiningWellnessService.cs, DiningWellnessService.cs
│   │   ├── Presenters/       # IDiningWellnessView.cs, DiningWellnessPresenter.cs
│   │   └── Components/       # DiningWellnessSection.razor
│   │
│   └── VirtualConcierge/     # Celeste AI Virtual Hospitality Assistant
│       ├── Models/           # ConciergeMessage.cs
│       ├── Services/         # IConciergeService.cs, ConciergeService.cs
│       ├── Presenters/       # IConciergeView.cs, ConciergePresenter.cs
│       └── Components/       # VirtualConciergeDrawer.razor
│
├── Shared/Components/        # LuxuryHeader, LuxuryFooter, HeroSection, NotificationToast
└── wwwroot/css/              # Compiled & minified Tailwind CSS
```

---

## 🚀 Key Features

1. **Dual-Perspective Experience**:
   - **Traveler Portal**: Discover luxury overwater villas, alpine chalets, safari pavilions; book excursions; build multi-day itineraries; reserve Michelin tables; interact with Celeste (AI Concierge).
   - **PMS Back-Office Hub**: Real-time room rack status (Occupied, Vacant Clean, Dirty Turnover, Maintenance), folio balance management, direct room charging, tour guide and vessel dispatch, housekeeping ticket workflow.
2. **Interactive Booking Engine**:
   - Add/remove stays and tours to active journey manifest.
   - Dynamic price calculations in USD, EUR, GBP, JPY, and AUD.
   - Promo discount validation (`AURA10` for 10% privilege discount, `LUXURY20` for 20%).
   - Generates digital room key pass and boarding voucher with celebration confetti.
3. **Tailwind CSS Styling**:
   - Luxury design system featuring emerald, gold, slate, and sand palettes.
   - Smooth transitions, glassmorphic floating bars, and responsive typography.

---

## 🛠️ How to Run

1. **Build Tailwind CSS**:
   ```bash
   npm run build:css
   ```
2. **Run the Blazor Application**:
   ```bash
   dotnet run --project AuraHospitality/AuraHospitality.csproj --launch-profile http
   ```
3. Open your browser at:
   ```
   http://localhost:5192
   ```
