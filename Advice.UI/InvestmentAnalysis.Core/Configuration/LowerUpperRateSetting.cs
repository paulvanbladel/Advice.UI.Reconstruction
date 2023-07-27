namespace InvestmentAnalysis.Core.Configuration;
public record class LowerUpperRateSetting
{
    public LowerUpperRateSetting(double lower, double upper, double rate)
    {
        Lower = lower;
        Upper = upper;
        Rate = rate;
    }
    public LowerUpperRateSetting()
    {

    }

    public double Lower { get; set; }
    public double Upper { get; set; }
    public double Rate { get; set; }
}