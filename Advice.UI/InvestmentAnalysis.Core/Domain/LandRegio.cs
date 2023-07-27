namespace InvestmentAnalysis.Core.Domain;
public record class LandRegio
{
    public Guid Id { get; set; }
    public string Naam_NL { get; set; }
    public string Naam_FR { get; set; }
    public string Naam_EN { get; set; }
    /// <summary>
    /// Een landregio behoort tot exact 1 Land
    /// </summary>
    public Land Land { get; set; }


}