namespace InvestmentAnalysis.Core.Domain;

public class VerbouwingsParameters
{
    public VerbouwingsParameters(TypeUitbestedeWerken typeUitbestedeWerken,
                                 BTWAwareKost uitbestedeWerken,
                                 BTWAwareKost nietAfgewerkteUitbestedeWerken,
                                 BTWAwareKost eigenWerken,
                                 BTWAwareKost architectEnBouwCoordinatorKost)
    {
        TypeUitbestedeWerken = typeUitbestedeWerken;
        UitbestedeWerken = uitbestedeWerken ?? BTWAwareKost.Zero();
        NietAfgewerkteUitbestedeWerken = nietAfgewerkteUitbestedeWerken ?? BTWAwareKost.Zero(); ;
        EigenWerken = eigenWerken ?? BTWAwareKost.Zero(); ;
        ArchitectEnBouwCoordinatorKost = architectEnBouwCoordinatorKost ?? BTWAwareKost.Zero(); ;
    }

    public TypeUitbestedeWerken TypeUitbestedeWerken { get; init; }
    public BTWAwareKost UitbestedeWerken { get; }
    public BTWAwareKost NietAfgewerkteUitbestedeWerken { get; init; }
    public BTWAwareKost EigenWerken { get; init; }
    public BTWAwareKost ArchitectEnBouwCoordinatorKost { get; init; }


    public Money TotalTVA
    {
        get
        {
            return UitbestedeWerken.TVA - NietAfgewerkteUitbestedeWerken.TVA + EigenWerken.TVA + ArchitectEnBouwCoordinatorKost.TVA;
        }
    }

    public Money TotalCost
    {
        get
        {
            return UitbestedeWerken.Cost - NietAfgewerkteUitbestedeWerken.Cost + EigenWerken.Cost + ArchitectEnBouwCoordinatorKost.Cost;
        }
    }
    public Money TotalCostWithoutTVA
    {
        get
        {
            return UitbestedeWerken.CostWithoutTVA - NietAfgewerkteUitbestedeWerken.CostWithoutTVA + EigenWerken.CostWithoutTVA + ArchitectEnBouwCoordinatorKost.CostWithoutTVA;
        }
    }
}
