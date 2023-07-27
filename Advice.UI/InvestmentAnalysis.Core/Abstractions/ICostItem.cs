using InvestmentAnalysis.Core.Configuration;
using InvestmentAnalysis.Core.Domain;

namespace InvestmentAnalysis.Core.Abstractions;

public interface ICostItem
{
    public CostCategory CostCategory { get; }
    public Money Cost { get; }
}
