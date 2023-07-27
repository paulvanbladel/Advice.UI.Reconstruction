using InvestmentAnalysis.Core.Abstractions;
using InvestmentAnalysis.Core.Configuration;
using InvestmentAnalysis.Core.Domain;

namespace InvestmentAnalysis.Core.CostItemTypes;

public abstract record class FixedCostItemBase : ICostItem
{
    public abstract CostCategory CostCategory { get; }
    public FixedCostItemBase(Money cost)
    {
        if (cost is null)
            throw new ArgumentNullException("Cost can't be null");

        if (cost < 0)
            throw new ArgumentOutOfRangeException(nameof(cost));

        Cost = cost;
    }

    public Money Cost { get; }
}

