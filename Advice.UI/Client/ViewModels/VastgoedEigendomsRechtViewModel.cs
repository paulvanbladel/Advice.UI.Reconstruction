
using ClassLibrary1;
using System.ComponentModel.DataAnnotations;

namespace Advice.UI.Client.ViewModels;

public record class VastgoedEigendomsRechtViewModel
{

    public OnroerendGoedGebruikType OnroerendGoedGebruikType { get; set; }
    public bool IsEigenWoning { get; set; }

    public double EigendomsPercentage { get; set; }
    [Editable(false)]
    public string NaamEigenaar { get; set; }
    //public Money MeeneembaarRegistratieRechtenBedrag { get; set; }

    public int AantalKinderenTenLaste { get; set; }
}
