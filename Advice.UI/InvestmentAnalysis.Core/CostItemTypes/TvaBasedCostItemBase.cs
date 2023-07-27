using InvestmentAnalysis.Core.Abstractions;
using InvestmentAnalysis.Core.Configuration;
using InvestmentAnalysis.Core.Domain;

namespace InvestmentAnalysis.Core.CostItemTypes;

public abstract record class TvaBasedCostItemBase : ITvaBasedCost
{
    public Money CostWithoutTVA { get; init; }

    public double TVAPercentage { get; init; }



    public TvaBasedCostItemBase(Money costWithoutTva, double tvaPercentage) : this(tvaPercentage)
    {
        if (costWithoutTva is null)
            throw new ArgumentNullException("costWithoutTva can't be null");
        if (costWithoutTva < 0)
            throw new ArgumentOutOfRangeException("costWithoutTva cannot be negative");


        CostWithoutTVA = costWithoutTva;
    }

    public TvaBasedCostItemBase(double tvaPercentage)
    {
        if (tvaPercentage < 0)
            throw new ArgumentOutOfRangeException("tvaPercentage cannot be negative");

        TVAPercentage = tvaPercentage;
    }

    public Money TVA
    {
        get
        {
            return CostWithoutTVA * TVAPercentage;
        }
    }
    public Money Cost
    {
        get
        {
            return CostWithoutTVA + TVA;
        }
    }

    public abstract CostCategory CostCategory { get; }
}

