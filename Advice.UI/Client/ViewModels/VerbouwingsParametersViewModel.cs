

namespace Advice.UI.Client.ViewModels;

public record class VerbouwingsParametersViewModel
{
    //public TypeUitbestedeWerken TypeUitbestedeWerken { get; init; }
    public double UitbestedeWerken { get; }
    public double NietAfgewerkteUitbestedeWerken { get; init; }
    public double EigenWerken { get; init; }
    public double ArchitectEnBouwCoordinatorKost { get; init; }
}
