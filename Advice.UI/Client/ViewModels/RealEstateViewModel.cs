using ClassLibrary1;
using System.Text.Json.Serialization;

namespace Advice.UI.Client.ViewModels;

public record class RealEstateViewModel
{

    public string Straat { get; set; }
    public string HuisNummer { get; set; }
    public string Bus { get; set; }
    public string PostNummer { get; set; }

    //TODO upgrade to real postnummer picker that uses the real postnummer json file
    //public Gemeente Gemeente { get; set; }
    public double KadastraalInkomen { get; set; }
    public WoningTypeVoorRegistratieRechten WoningTypeVoorRegistratieRechten { get; set; }
    public OnroerendGoedType OnroerendGoedType { get; set; }


}
