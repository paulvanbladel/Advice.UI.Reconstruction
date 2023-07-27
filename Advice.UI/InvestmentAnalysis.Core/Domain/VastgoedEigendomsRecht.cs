namespace InvestmentAnalysis.Core.Domain;

/// <summary>
/// Properties of the eigenaar in the context of the transaction that is modelled
/// </summary>
public record class VastgoedEigendomsRecht
{
    public VastgoedEigendomsRecht(
        string name,
        double eigendomsPercentage,
        Money meeneembaarRegistratieRechtenBedrag,
        OnroerendGoedGebruikType onroerendGoedGebruikType = OnroerendGoedGebruikType.AnderOnroerendGoed,
        bool isEigenWoning = false)
    {
        OnroerendGoedGebruikType = onroerendGoedGebruikType;
        IsEigenWoning = isEigenWoning;
        MeeneembaarRegistratieRechtenBedrag = meeneembaarRegistratieRechtenBedrag;
        EigendomsPercentage = eigendomsPercentage;
        NaamEigenaar = name;
    }
    public OnroerendGoedGebruikType OnroerendGoedGebruikType { get; }
    public bool IsEigenWoning { get; }

    public bool IsEigenEnigeWoning
    {
        get
        {
            return IsEigenWoning && OnroerendGoedGebruikType == OnroerendGoedGebruikType.EnigeWoning;
        }
    }
    public double EigendomsPercentage { get; }
    public string NaamEigenaar { get; }
    public Money MeeneembaarRegistratieRechtenBedrag { get; }


    public bool MeeneembaarheidToepasbaar
    {
        get
        {
            return MeeneembaarRegistratieRechtenBedrag.Amount > 0;
        }
    }
}