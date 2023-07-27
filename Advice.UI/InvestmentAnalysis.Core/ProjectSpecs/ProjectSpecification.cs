using InvestmentAnalysis.Core.Domain;

namespace InvestmentAnalysis.Core.ProjectSpecs;

public record class ProjectSpecification
{
    public ProjectType ProjectType { get; init; }

    /// <summary>
    /// Is either aankoopnieuw or aankoopnieuw met grond onder registratierechten
    /// </summary>
    public bool IsAankoopNieuwBouw
    {
        get
        {
            return ProjectType == ProjectType.AankoopNieuwBouw || ProjectType == ProjectType.AankoopNieuwBouwMetGrondOnderRegistratieRechten;
        }
    }
    public DateTime AankoopDatumVastgoed { get; init; }
    public DateTime HypothecaireLeningStartDatum { get; init; }
    public WoningTypeVoorRegistratieRechten WoningType { get; init; }
    public NieuwBouwType NieuwBouwType { get; init; }
    public Money WoningKost { get; init; }
    public Money GrondKost { get; init; }

    public Money GecombineerdeWoningGrondKost
    {
        get
        {
            return WoningKost + GrondKost;
        }
    }

    public Money GecombineerdeAdditioneleKosten
    {
        get
        {
            return VerbouwingsParameters.TotalCost + AndereAankoopKosten.TotalCost + Herfinanciering.TotalCost;
        }
    }
    public bool IsBebouwd
    {
        get
        {
            return ProjectType != ProjectType.AankoopGrond;
        }
    }
    public Money RegistratieRechtenBasisBedrag
    {
        get
        {
            return ProjectType switch
            {
                ProjectType.AankoopBestaandeWoning => WoningKost,
                ProjectType.AankoopNieuwBouw => 0,
                ProjectType.AankoopNieuwBouwMetGrondOnderRegistratieRechten => GrondKost,
                ProjectType.AankoopGrond => GrondKost,
                _ => throw new ArgumentException("Unknown project type"),
            };
        }
    }
    public Money BtwBasisBedrag
    {
        get
        {
            return ProjectType switch
            {
                ProjectType.AankoopBestaandeWoning => 0,
                ProjectType.AankoopNieuwBouw => WoningKost + GrondKost,
                ProjectType.AankoopNieuwBouwMetGrondOnderRegistratieRechten => WoningKost,
                ProjectType.AankoopGrond => 0,
                _ => throw new ArgumentException("Unknown project type"),
            };
        }
    }
    /// <summary>
    /// Nog een side note ivm BTW of RR op grond (een nota van maken in de code ?)
    ///Grond onder RR en Huis onder BTW kan alleen als er twee verkopers zijn
    ///Eerste eigenaar verkoopt de grond en tweede eigenaar verkoopt het huis
    ///Typisch een aannemer die het huis verkoopt en een andere entiteit(legaal , persoon) die de grond verkoopt
    /// </summary>
    // public bool? GrondIsMetBtw { get; init; }
    /// <summary>
    /// Threshold die bepaalt tot welk bedrag lage btw tarief kan toegepast worden.
    /// </summary>
    public Money BtwTresholdValue { get; init; }

    public HypotheekMandaatBedragConfiguratie HypotheekMandaatBedragConfiguratie { get; init; }
    public VastgoedAdres? VastgoedAdres { get; init; }
    public ToepasbareRegio ToepasbareRegio { get; init; }
    /// <summary>
    /// Only applicable for Vlaanderen
    /// </summary>
    public bool? GemeenteIsVlaamseKernStad { get; init; }
    public ToepasbareVastgoedDrukWaalseStad? ToepasbareVastgoedDrukWaalseStad { get; init; }
    public VerbouwingsParameters? VerbouwingsParameters { get; init; }
    public AndereAankoopKosten? AndereAankoopKosten { get; init; }
    public Herfinanciering? Herfinanciering { get; }
    public bool? IsPandInOpbouw { get; }
    public Money? AnderePanden { get; }

    /// <summary>
    /// Nullability is debatable
    /// </summary>
    public Money? KadastraalInkomen { get; init; }
    public int AantalKinderenTenLaste { get; init; }
    public IList<VastgoedEigendomsRecht> EigendomsRechten { get; init; } = new List<VastgoedEigendomsRecht>();
    public VerkoopType VerkoopType { get; init; }
    public bool? AlleEigenaarsEnigeEigenWoning => EigendomsRechten.All(e => e.IsEigenEnigeWoning == true);
    public static ProjectSpecification CreateBestaandeWoningProject(DateTime aankoopDatumVastgoed,
                                                                    DateTime hypothecaireLeningStartDatum,
                                                                    Money woningKost,
                                                                    HypotheekMandaatBedragConfiguratie hypotheekMandaatBedragConfiguratie,
                                                                    ToepasbareRegio toepasbareRegio,
                                                                    Money kadadstraalInkomen,
                                                                    IList<VastgoedEigendomsRecht> eigendomsRechten,
                                                                    VerkoopType verkoopType = VerkoopType.UitDeHand,
                                                                    WoningTypeVoorRegistratieRechten woningType = WoningTypeVoorRegistratieRechten.Normaal,
                                                                    int aantalKinderenTenLaste = 2,
                                                                    VastgoedAdres? vastgoedAdres = null,
                                                                    bool? gemeenteIsVlaamseKernStad = null,
                                                                    ToepasbareVastgoedDrukWaalseStad? toepasbareVastgoedDrukWaalseStad = null,
                                                                    VerbouwingsParameters? verbouwingsParameters = null,
                                                                    AndereAankoopKosten andereAankoopKosten = null,
                                                                    Herfinanciering? herfinanciering = null,
                                                                    Money? anderePanden = null
                                                                    )
    {
        var projectType = ProjectType.AankoopBestaandeWoning;
        return new ProjectSpecification(projectType,
                                        aankoopDatumVastgoed: aankoopDatumVastgoed,
                                        hypothecaireLeningStartDatum: hypothecaireLeningStartDatum,
                                        woningKost,
                                        grondKost: 0,
                                        btwThresholdValue: 0,
                                        hypotheekMandaatBedragConfiguratie: hypotheekMandaatBedragConfiguratie,
                                        toepasbareRegio: toepasbareRegio,
                                        kadadstraalInkomen: kadadstraalInkomen,
                                        eigendomsRechten: eigendomsRechten,
                                        verkoopType: verkoopType,
                                        woningType: woningType,
                                        nieuwBouwType: NieuwBouwType.NietVanToepassing,
                                        aantalKinderenTenLaste: aantalKinderenTenLaste,
                                        vastgoedAdres: vastgoedAdres,
                                        gemeenteIsVlaamseKernStad: gemeenteIsVlaamseKernStad,
                                        toepasbareVastgoedDrukWaalseStad: toepasbareVastgoedDrukWaalseStad,
                                        verbouwingsParameters: verbouwingsParameters,
                                        andereAankoopKosten: andereAankoopKosten,
                                        herfinanciering: herfinanciering,
                                        anderePanden: anderePanden
                                        );
    }

    public static ProjectSpecification CreateNieuwbouwProject(DateTime aankoopDatumVastgoed,
                                                              DateTime hypothecaireLeningStartDatum,
                                                              Money woningKost,
                                                              Money grondKost,
                                                              Money btwThresholdValue,
                                                              //bool grondIsMetBtw,
                                                              HypotheekMandaatBedragConfiguratie hypotheekMandaatBedragConfiguratie,
                                                              ToepasbareRegio toepasbareRegio,
                                                              Money kadadstraalInkomen,
                                                              IList<VastgoedEigendomsRecht> eigendomsRechten,
                                                              VerkoopType verkoopType = VerkoopType.UitDeHand,
                                                              WoningTypeVoorRegistratieRechten woningType = WoningTypeVoorRegistratieRechten.Normaal,
                                                              NieuwBouwType nieuwBouwType = NieuwBouwType.VerkoopOpPlan,
                                                              int aantalKinderenTenLaste = 2,
                                                              VastgoedAdres? vastgoedAdres = null,
                                                              bool? gemeenteIsVlaamseKernStad = null,
                                                              ToepasbareVastgoedDrukWaalseStad? toepasbareVastgoedDrukWaalseStad = null,
                                                              VerbouwingsParameters? verbouwingsParameters = null,
                                                              AndereAankoopKosten andereAankoopKosten = null,
                                                              Herfinanciering? herfinanciering = null,
                                                              bool isPandInOpbouw = false,
                                                              Money? anderePanden = null


        )
    {



        var projectType = ProjectType.AankoopNieuwBouw;

        return new ProjectSpecification(projectType, aankoopDatumVastgoed,
                                        hypothecaireLeningStartDatum: hypothecaireLeningStartDatum,
                                        woningKost: woningKost,
                                        grondKost: grondKost,
                                        btwThresholdValue: btwThresholdValue,
                                        hypotheekMandaatBedragConfiguratie: hypotheekMandaatBedragConfiguratie,
                                        toepasbareRegio: toepasbareRegio,
                                        kadadstraalInkomen: kadadstraalInkomen,
                                        eigendomsRechten: eigendomsRechten,
                                        verkoopType: verkoopType,
                                        woningType: woningType,
                                        nieuwBouwType: nieuwBouwType,
                                        aantalKinderenTenLaste: aantalKinderenTenLaste,
                                        vastgoedAdres: vastgoedAdres,
                                        gemeenteIsVlaamseKernStad: gemeenteIsVlaamseKernStad,
                                        toepasbareVastgoedDrukWaalseStad: toepasbareVastgoedDrukWaalseStad,
                                        verbouwingsParameters: verbouwingsParameters,
                                        andereAankoopKosten: andereAankoopKosten,
                                        herfinanciering: herfinanciering,
                                        isPandInOpbouw: isPandInOpbouw,
                                        anderePanden: anderePanden);

    }

    public static ProjectSpecification CreateNieuwbouwProjectMetGrondOnderRegistratieRechten(DateTime aankoopDatumVastgoed,
                                                              DateTime hypothecaireLeningStartDatum,
                                                              Money woningKost,
                                                              Money grondKost,
                                                              Money btwThresholdValue,
                                                              HypotheekMandaatBedragConfiguratie hypotheekMandaatBedragConfiguratie,
                                                              ToepasbareRegio toepasbareRegio,
                                                              Money kadadstraalInkomen,
                                                              IList<VastgoedEigendomsRecht> eigendomsRechten,
                                                              VerkoopType verkoopType = VerkoopType.UitDeHand,
                                                              WoningTypeVoorRegistratieRechten woningType = WoningTypeVoorRegistratieRechten.Normaal,
                                                              NieuwBouwType nieuwBouwType = NieuwBouwType.VerkoopOpPlan,
                                                              int aantalKinderenTenLaste = 2,
                                                              VastgoedAdres? vastgoedAdres = null,
                                                              bool? gemeenteIsVlaamseKernStad = null,
                                                              ToepasbareVastgoedDrukWaalseStad? toepasbareVastgoedDrukWaalseStad = null,
                                                              VerbouwingsParameters? verbouwingsParameters = null,
                                                              AndereAankoopKosten andereAankoopKosten = null,
                                                              Herfinanciering? herfinanciering = null,
                                                              bool isPandInOpbouw = false,
                                                              Money? anderePanden = null

        )
    {
        var projectType = ProjectType.AankoopNieuwBouwMetGrondOnderRegistratieRechten;

        return new ProjectSpecification(projectType, aankoopDatumVastgoed,
                                        hypothecaireLeningStartDatum: hypothecaireLeningStartDatum,
                                        woningKost: woningKost,
                                        grondKost: grondKost,
                                        btwThresholdValue: btwThresholdValue,
                                        hypotheekMandaatBedragConfiguratie: hypotheekMandaatBedragConfiguratie,
                                        toepasbareRegio: toepasbareRegio,
                                        kadadstraalInkomen: kadadstraalInkomen,
                                        eigendomsRechten: eigendomsRechten,
                                        verkoopType: verkoopType,
                                        woningType: woningType,
                                        nieuwBouwType: nieuwBouwType,
                                        aantalKinderenTenLaste: aantalKinderenTenLaste,
                                        vastgoedAdres: vastgoedAdres,
                                        gemeenteIsVlaamseKernStad: gemeenteIsVlaamseKernStad,
                                        toepasbareVastgoedDrukWaalseStad: toepasbareVastgoedDrukWaalseStad,
                                        verbouwingsParameters: verbouwingsParameters,
                                        andereAankoopKosten: andereAankoopKosten,
                                        herfinanciering: herfinanciering,
                                        isPandInOpbouw: isPandInOpbouw, anderePanden: anderePanden);

    }

    public static ProjectSpecification CreateAankoopGrond(DateTime aankoopDatumVastgoed,
                                                          DateTime hypothecaireLeningStartDatum,
                                                          Money grondKost,
                                                          HypotheekMandaatBedragConfiguratie hypotheekMandaatBedragConfiguratie,
                                                          ToepasbareRegio toepasbareRegio,
                                                          Money kadadstraalInkomen,
                                                          IList<VastgoedEigendomsRecht> eigendomsRechten,
                                                          VerkoopType verkoopType = VerkoopType.UitDeHand,
                                                          int aantalKinderenTenLaste = 2,
                                                          VastgoedAdres? vastgoedAdres = null,
                                                          bool? gemeenteIsVlaamseKernStad = null,
                                                          ToepasbareVastgoedDrukWaalseStad? toepasbareVastgoedDrukWaalseStad = null,
                                                          Money? anderePanden = null)
    {
        var projectType = ProjectType.AankoopGrond;
        return new ProjectSpecification(projectType,
                                        aankoopDatumVastgoed,
                                        hypothecaireLeningStartDatum,
                                        woningKost: 0,
                                        grondKost,
                                        btwThresholdValue: 0,
                                        hypotheekMandaatBedragConfiguratie: hypotheekMandaatBedragConfiguratie,
                                        toepasbareRegio: toepasbareRegio,
                                        kadadstraalInkomen: kadadstraalInkomen,
                                        eigendomsRechten: eigendomsRechten,
                                        verkoopType: verkoopType,
                                        woningType: WoningTypeVoorRegistratieRechten.NietVanToepassing,
                                        nieuwBouwType: NieuwBouwType.NietVanToepassing,
                                        aantalKinderenTenLaste: aantalKinderenTenLaste,
                                        vastgoedAdres: vastgoedAdres,
                                        gemeenteIsVlaamseKernStad: gemeenteIsVlaamseKernStad,
                                        toepasbareVastgoedDrukWaalseStad: toepasbareVastgoedDrukWaalseStad,
                                        anderePanden: anderePanden);

    }
    private ProjectSpecification(ProjectType projectType,
                                 DateTime aankoopDatumVastgoed,
                                 DateTime hypothecaireLeningStartDatum,
                                 Money woningKost,
                                 Money grondKost,
                                 Money btwThresholdValue,
                                 HypotheekMandaatBedragConfiguratie hypotheekMandaatBedragConfiguratie,
                                 ToepasbareRegio toepasbareRegio,
                                 Money kadadstraalInkomen,
                                 IList<VastgoedEigendomsRecht> eigendomsRechten,
                                 VerkoopType verkoopType,
                                 WoningTypeVoorRegistratieRechten woningType = WoningTypeVoorRegistratieRechten.NietVanToepassing,
                                 NieuwBouwType nieuwBouwType = NieuwBouwType.NietVanToepassing,
                                 int aantalKinderenTenLaste = 2,
                                 VastgoedAdres? vastgoedAdres = null,
                                 bool? gemeenteIsVlaamseKernStad = null,
                                 ToepasbareVastgoedDrukWaalseStad? toepasbareVastgoedDrukWaalseStad = null,
                                 VerbouwingsParameters? verbouwingsParameters = null,
                                 AndereAankoopKosten andereAankoopKosten = null,
                                 Herfinanciering? herfinanciering = null,
                                 bool? isPandInOpbouw = false,
                                 Money? anderePanden = null)
    {

        DateTime startDateEngine = new DateTime(2020, 12, 31);




        if (aankoopDatumVastgoed < startDateEngine)
            throw new ArgumentOutOfRangeException($"The engine works only dates later than {startDateEngine}");

        if (hypothecaireLeningStartDatum < startDateEngine)
            throw new ArgumentOutOfRangeException($"The engine works only dates later than {startDateEngine}");

        ProjectType = projectType;
        AankoopDatumVastgoed = aankoopDatumVastgoed;
        HypothecaireLeningStartDatum = hypothecaireLeningStartDatum;
        WoningKost = woningKost;
        GrondKost = grondKost;
        BtwTresholdValue = btwThresholdValue;
        HypotheekMandaatBedragConfiguratie = hypotheekMandaatBedragConfiguratie;
        ToepasbareRegio = toepasbareRegio;
        KadastraalInkomen = kadadstraalInkomen;
        EigendomsRechten = eigendomsRechten;
        VerkoopType = verkoopType;
        WoningType = woningType;
        NieuwBouwType = nieuwBouwType;
        AantalKinderenTenLaste = aantalKinderenTenLaste;
        VastgoedAdres = vastgoedAdres;
        GemeenteIsVlaamseKernStad = gemeenteIsVlaamseKernStad;
        ToepasbareVastgoedDrukWaalseStad = toepasbareVastgoedDrukWaalseStad;

        //if (toepasbareRegio == ToepasbareRegio.Vlaanderen && gemeenteIsVlaamseKernStad is null)
        //{
        //    throw new InvalidDataException($"Parameter {nameof(gemeenteIsVlaamseKernStad)} is mandatory when Regio is {nameof(ToepasbareRegio.Vlaanderen)}");
        //}



        //if (toepasbareRegio == ToepasbareRegio.Wallonie && toepasbareVastgoedDrukWaalseStad is null)
        //{
        //    throw new InvalidDataException($"Parameter {nameof(toepasbareVastgoedDrukWaalseStad)} is mandatory when Regio is {nameof(ToepasbareRegio.Wallonie)}");
        //}


        VerbouwingsParameters = verbouwingsParameters;
        AndereAankoopKosten = andereAankoopKosten;
        Herfinanciering = herfinanciering;
        IsPandInOpbouw = isPandInOpbouw;
        AnderePanden = anderePanden;

    }
}