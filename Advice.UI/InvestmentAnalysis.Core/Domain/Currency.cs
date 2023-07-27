namespace InvestmentAnalysis.Core.Domain
{
    public record class Currency
    {
        public static Currency EUR = new Currency { CurrencyCode = "EUR" };
        public string CurrencyCode { get; set; }
    }
}