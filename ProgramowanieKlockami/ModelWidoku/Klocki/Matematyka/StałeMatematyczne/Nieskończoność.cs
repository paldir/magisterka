using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class Nieskończoność : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "∞";
        public override double Wartość => double.PositiveInfinity;
    }
}