
using System;

namespace Advice.UI.Client.ViewModels;

public record class SalesDetailsViewModel
{
    //public VerkoopType VerkoopType { get; set; }
    public DateTime AankoopDatumVastgoed { get; set; } = DateTime.Now;
}
