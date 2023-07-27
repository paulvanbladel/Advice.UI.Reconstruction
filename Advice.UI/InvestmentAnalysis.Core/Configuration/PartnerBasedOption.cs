namespace InvestmentAnalysis.Core.Configuration
{
    public record PartnerBasedOption<T>
    {
        public int PartnerId { get; set; }
        public IntervalBasedOption<T>[] PartnerData { get; set; }
    }
}