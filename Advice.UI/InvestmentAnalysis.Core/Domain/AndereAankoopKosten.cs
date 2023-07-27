namespace InvestmentAnalysis.Core.Domain;
public class AndereAankoopKosten
{
    public AndereAankoopKosten(Money aansluitingen,
                               Money waarborgPremie,
                               Money dossierKostenEnExpertiseKosten,
                               string beschrijvingingAdditioneleKosten,
                               Money additioneleKosten
                               )
    {
        Aansluitingen = aansluitingen ?? 0;
        WaarborgPremie = waarborgPremie ?? 0;
        DossierKostenEnExpertiseKosten = dossierKostenEnExpertiseKosten ?? 0;
        
        BeschrijvingingAdditioneleKosten = beschrijvingingAdditioneleKosten;
        AdditioneleKosten = additioneleKosten ?? 0;
    }

    public Money Aansluitingen { get; init; }
    public Money WaarborgPremie { get; init; }
    public Money DossierKostenEnExpertiseKosten { get; init; }
    public string BeschrijvingingAdditioneleKosten { get; init; }
    public Money AdditioneleKosten { get; init; }

    public Money TotalCost
    {
        get
        {
            return Aansluitingen + WaarborgPremie + DossierKostenEnExpertiseKosten +  AdditioneleKosten;
        }
    }
}
