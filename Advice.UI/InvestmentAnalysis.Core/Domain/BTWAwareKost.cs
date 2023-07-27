using InvestmentAnalysis.Core.Configuration;
using InvestmentAnalysis.Core.CostItemTypes;

namespace InvestmentAnalysis.Core.Domain;

public record class BTWAwareKost : TvaBasedCostItemBase
{
    public BTWAwareKost(Money costWithoutTva, double tvaPercentage) : base(costWithoutTva, tvaPercentage)
    {
    }

    public override CostCategory CostCategory => $"TBD";
    public static BTWAwareKost Zero()
    {
        return new BTWAwareKost(0, 0);
    }
}
