namespace InvestmentAnalysis.Core.Domain;

public record class HypotheekMandaatBedragConfiguratie
{
    public HypotheekMandaatBedragConfiguratie(Money hypotheekDeel, Money mandaatDeel)
    {
        HypotheekDeel = hypotheekDeel;
        MandaatDeel = mandaatDeel;
    }

    public Money HypotheekDeel { get; init; }
    public Money MandaatDeel { get; init; }
    public Money TotaalLening
    {
        get
        {
            return HypotheekDeel + MandaatDeel;
        }
    }
}