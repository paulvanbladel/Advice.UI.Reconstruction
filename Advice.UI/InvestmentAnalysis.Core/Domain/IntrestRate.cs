using System.Globalization;

namespace InvestmentAnalysis.Core.Domain;
public record class IntrestRate
{
    private double _yearlyIntrestRate;
    protected IntrestRate(double yearlyIntrestRate)
    {
        _yearlyIntrestRate = yearlyIntrestRate;
    }
    public double Monthly
    {
        get
        {
            return Math.Round(ConvertYearlyToMonthly(_yearlyIntrestRate) * 100, 2);
        }
    }

    public double Yearly
    {
        get
        {
            return Math.Round(_yearlyIntrestRate * 100.00, 2);
        }
    }
    public static IntrestRate FromMonthly(double monthlyIntrestRate)
    {
        double yearlyIntrestRate = ConvertMonthlyToYearly(monthlyIntrestRate);
        return new IntrestRate(yearlyIntrestRate);
    }
    public static IntrestRate FromYearlyAsDouble(double yearlyIntrestRate)
    {
        return new IntrestRate(yearlyIntrestRate);
    }

    private static double ConvertMonthlyToYearly(double monthlyIntrestRate)
    {
        return Math.Pow(1 + monthlyIntrestRate, 12.00) - 1.00;
    }

    private static double ConvertYearlyToMonthly(double yearlyIntrestRate)
    {
        return Math.Pow(1 + yearlyIntrestRate, 1.00 / 12.00) - 1.00;
    }
    public override string ToString()
    {
        return $"{Yearly.ToString(CultureInfo.InvariantCulture)} % Yearly --- {Monthly.ToString(CultureInfo.InvariantCulture)} % Monthly";
    }
}


