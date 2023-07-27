namespace InvestmentAnalysis.Core.Domain;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// In tegenstelling tot het woningaddress, kan een persoon ook een buitenlands adres hebben.
/// </remarks>
public record class Persoon
{
    public Persoon(string name)
    {
        Name = name;
    }

    public string Name { get; }
}