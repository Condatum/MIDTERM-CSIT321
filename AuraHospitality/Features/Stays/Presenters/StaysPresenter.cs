using AuraHospitality.Features.Stays.Models;

namespace AuraHospitality.Features.Stays.Presenters;

public interface IStaysView
{
    void DisplayStays(IReadOnlyList<Stay> stays);
    void DisplayCategories(IReadOnlyList<string> categories);
    void DisplayStayDetail(Stay? stay);
    void SetLoading(bool isLoading);
    void ShowErrorMessage(string message);
}

public class StaysPresenter
{
    private readonly Services.IStaysRepository _repository;
    private readonly Core.Services.ICurrencyService _currencyService;
    private readonly Core.Services.IAppStateService _appState;
    private IStaysView? _view;

    public StayFilterCriteria Criteria { get; private set; } = new();

    public StaysPresenter(
        Services.IStaysRepository repository,
        Core.Services.ICurrencyService currencyService,
        Core.Services.IAppStateService appState)
    {
        _repository = repository;
        _currencyService = currencyService;
        _appState = appState;
    }

    public void AttachView(IStaysView view)
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

            var stays = await _repository.GetAllStaysAsync();
            _view.DisplayStays(stays);
        }
        catch (Exception ex)
        {
            _view.ShowErrorMessage($"Failed to load luxury stays: {ex.Message}");
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
            var stays = await _repository.FilterStaysAsync(Criteria);
            _view.DisplayStays(stays);
        }
        finally
        {
            _view.SetLoading(false);
        }
    }

    public async Task ViewStayDetailsAsync(string stayId)
    {
        if (_view == null) return;
        var stay = await _repository.GetStayByIdAsync(stayId);
        _view.DisplayStayDetail(stay);
    }

    public void CloseStayDetails()
    {
        _view?.DisplayStayDetail(null);
    }
}
