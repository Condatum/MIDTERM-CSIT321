using AuraHospitality.Features.Tours.Models;

namespace AuraHospitality.Features.Tours.Presenters;

public interface IToursView
{
    void DisplayTours(IReadOnlyList<Tour> tours);
    void DisplayCategories(IReadOnlyList<string> categories);
    void DisplayTourDetail(Tour? tour);
    void SetLoading(bool isLoading);
    void ShowErrorMessage(string message);
}

public class ToursPresenter
{
    private readonly Services.IToursRepository _repository;
    private readonly Core.Services.ICurrencyService _currencyService;
    private readonly Core.Services.IAppStateService _appState;
    private IToursView? _view;

    public TourFilterCriteria Criteria { get; private set; } = new();

    public ToursPresenter(
        Services.IToursRepository repository,
        Core.Services.ICurrencyService currencyService,
        Core.Services.IAppStateService appState)
    {
        _repository = repository;
        _currencyService = currencyService;
        _appState = appState;
    }

    public void AttachView(IToursView view)
    {
        _view = view;
    }

    public async Task InitializeAsync()
    {
        if (_view == null) return;
        _view.SetLoading(true);
        try
        {
            var categories = await _repository.GetCategoriesAsync();
            _view.DisplayCategories(categories);

            var tours = await _repository.GetAllToursAsync();
            _view.DisplayTours(tours);
        }
        catch (Exception ex)
        {
            _view.ShowErrorMessage($"Failed to load expeditions: {ex.Message}");
        }
        finally
        {
            _view.SetLoading(false);
        }
    }

    public async Task FilterByCategoryAsync(string category)
    {
        Criteria.Category = category;
        await ApplyFiltersAsync();
    }

    public async Task SearchAsync(string query)
    {
        Criteria.SearchQuery = query;
        await ApplyFiltersAsync();
    }

    public async Task ApplyFiltersAsync()
    {
        if (_view == null) return;
        _view.SetLoading(true);
        try
        {
            var tours = await _repository.FilterToursAsync(Criteria);
            _view.DisplayTours(tours);
        }
        finally
        {
            _view.SetLoading(false);
        }
    }

    public async Task ViewTourDetailsAsync(string tourId)
    {
        if (_view == null) return;
        var tour = await _repository.GetTourByIdAsync(tourId);
        _view.DisplayTourDetail(tour);
    }

    public void CloseTourDetails()
    {
        _view?.DisplayTourDetail(null);
    }
}
