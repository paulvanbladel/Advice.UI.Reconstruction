namespace InvestmentAnalysis.Core.Domain;

public class Herfinanciering
{
    public Money OpenstaandKapitaal { get; init; }
    public Money WederbeleggingsVergoeding { get; }
    public Money HandLichting { get; }

    public Herfinanciering(Money openstaandKapitaal, Money wederbeleggingsVergoeding, Money handLichting)
    {
        OpenstaandKapitaal = openstaandKapitaal ?? 0;
        WederbeleggingsVergoeding = wederbeleggingsVergoeding ?? 0;
        HandLichting = handLichting ?? 0;
    }

    public Money TotalCost
    {
        get
        {
            return OpenstaandKapitaal + WederbeleggingsVergoeding + HandLichting;
        }
    }
}
