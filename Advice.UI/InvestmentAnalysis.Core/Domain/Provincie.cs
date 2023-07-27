namespace InvestmentAnalysis.Core.Domain;

public record class Provincie
{
    public Guid Id { get; set; }
    public string Naam_NL { get; set; }
    public string Naam_FR { get; set; }
    public string Naam_EN { get; set; }
    /// <summary>
    /// Een Provincie behoort tot exact één landRegion
    /// </summary>
    public LandRegio LandRegio { get; set; }
}