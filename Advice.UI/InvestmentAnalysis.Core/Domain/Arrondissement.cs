namespace InvestmentAnalysis.Core.Domain;
public record class Arrondissement
{
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Alternatieve unieke sleutel</remarks>
    public string NIS { get; set; }
    public string Naam_NL { get; set; }
    public string Naam_FR { get; set; }
    public string Naam_EN { get; set; }
    /// <summary>
    /// Een arrondissement behoort tot exact 1 provincie
    /// </summary>
    public Provincie Provincie { get; set; }
}