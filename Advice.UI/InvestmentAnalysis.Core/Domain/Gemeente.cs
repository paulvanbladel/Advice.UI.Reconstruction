namespace InvestmentAnalysis.Core.Domain;
public record class Gemeente
{
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>alternatieve sleutel</remarks>
    public string PostNummer { get; set; }
    public string Naam_NL { get; set; }
    public string Naam_FR { get; set; }
    public string Naam_EN { get; set; }


    /// <summary>
    /// Een gemeente behoort tot exact één Arrondissement
    /// </summary>
    public Arrondissement Arrondissement { get; set; }
    public string NisCode { get; set; }
}