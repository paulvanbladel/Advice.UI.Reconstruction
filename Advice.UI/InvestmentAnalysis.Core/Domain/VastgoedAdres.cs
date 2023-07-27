namespace InvestmentAnalysis.Core.Domain;

/// <summary>
/// een woning adres moet in belgie zijn zodat, de cost engine ook aan arrondissement e.d. kan
/// </summary>
public record class VastgoedAdres
{
    public VastgoedAdres(string straat, string huisNummer, string bus, Gemeente gemeente)
    {
        Straat = straat;
        HuisNummer = huisNummer;
        Bus = bus;
        Gemeente = gemeente;
    }

    public string Straat { get; set; }
    public string HuisNummer { get; set; }
    public string Bus { get; set; }
    public Gemeente Gemeente { get; set; }
}