namespace Advice.UI.Client.ViewModels
{
    public record class AndereAankoopKostenViewModel
    {
        public double Aansluitingen { get; init; }
        public double WaarborgPremie { get; init; }
        public double DossierKostenEnExpertiseKosten { get; init; }
        public string BeschrijvingingAdditioneleKosten { get; init; }
        public double AdditioneleKosten { get; init; }

    }


}
