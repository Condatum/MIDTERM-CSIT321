using AuraHospitality.Core.Models;

namespace AuraHospitality.Core.Services;

public interface ICurrencyService
{
    CurrencyInfo CurrentCurrency { get; }
    event Action? OnCurrencyChanged;
    void SetCurrency(string code);
    string FormatPrice(decimal usdAmount);
    decimal ConvertFromUsd(decimal usdAmount);
}

public class CurrencyService : ICurrencyService
{
    private CurrencyInfo _currentCurrency = SupportedCurrencies.All["USD"];

    public CurrencyInfo CurrentCurrency => _currentCurrency;

    public event Action? OnCurrencyChanged;

    public void SetCurrency(string code)
    {
        if (SupportedCurrencies.All.TryGetValue(code, out var currency))
        {
            _currentCurrency = currency;
            OnCurrencyChanged?.Invoke();
        }
    }

    public decimal ConvertFromUsd(decimal usdAmount)
    {
        return usdAmount * _currentCurrency.ExchangeRate;
    }

    public string FormatPrice(decimal usdAmount)
    {
        var converted = ConvertFromUsd(usdAmount);
        if (_currentCurrency.Code == "JPY")
        {
            return $"{_currentCurrency.Symbol}{Math.Round(converted):N0}";
        }
        return $"{_currentCurrency.Symbol}{converted:N0}";
    }
}
