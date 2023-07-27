namespace InvestmentAnalysis.Core.Configuration;
public record class IntervalBasedOption<T>
{
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public T Value { get; set; }
}
