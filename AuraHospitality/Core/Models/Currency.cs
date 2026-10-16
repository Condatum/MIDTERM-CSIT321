namespace AuraHospitality.Core.Models;

public record CurrencyInfo(string Code, string Symbol, decimal ExchangeRate, string Label);

public static class SupportedCurrencies
{
    public static readonly Dictionary<string, CurrencyInfo> All = new()
    {
        { "USD", new CurrencyInfo("USD", "$", 1.0m, "USD ($)") },
        { "EUR", new CurrencyInfo("EUR", "€", 0.92m, "EUR (€)") },
        { "GBP", new CurrencyInfo("GBP", "£", 0.79m, "GBP (£)") },
        { "JPY", new CurrencyInfo("JPY", "¥", 154.5m, "JPY (¥)") },
        { "AUD", new CurrencyInfo("AUD", "A$", 1.52m, "AUD (A$)") }
    };
}
