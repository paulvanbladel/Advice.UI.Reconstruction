using InvestmentAnalysis.Core.Attributes;

namespace InvestmentAnalysis.Core.Domain;

public sealed record class OverBruggingsKredietSaldo
{
    public OverBruggingsKredietSaldo(Money overbruggingsKrediet,
                                Money kostenOverbruggingsKrediet,
                                Money openstaandSaldoBestaandeLening,
                                Money wederbeleggingsVergoeding,
                                Money handlichting,
                                Money commissieImmoMakelaar)
    {
        OverbruggingsKrediet = overbruggingsKrediet;
        KostenOverbruggingsKrediet = kostenOverbruggingsKrediet;
        OpenstaandSaldoBestaandeLening = openstaandSaldoBestaandeLening;
        WederbeleggingsVergoeding = wederbeleggingsVergoeding;
        Handlichting = handlichting;
        CommissieImmoMakelaar = commissieImmoMakelaar;
    }
    [MoneyDebet]
    public Money OverbruggingsKrediet { get; }
    [MoneyCredit]
    public Money KostenOverbruggingsKrediet { get; }
    [MoneyCredit] 
    public Money OpenstaandSaldoBestaandeLening { get; }
    [MoneyCredit]
    public Money WederbeleggingsVergoeding { get; }
    [MoneyCredit]
    public Money Handlichting { get; }
    [MoneyCredit]
    public Money CommissieImmoMakelaar { get; }
}