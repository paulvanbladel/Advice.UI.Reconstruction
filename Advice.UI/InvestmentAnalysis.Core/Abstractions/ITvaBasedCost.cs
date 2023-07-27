using InvestmentAnalysis.Core.Domain;

namespace InvestmentAnalysis.Core.Abstractions;

public interface ITvaBasedCost : ICostItem
{
    Money CostWithoutTVA { get; }
    double TVAPercentage { get; }
    Money TVA { get; }
}
