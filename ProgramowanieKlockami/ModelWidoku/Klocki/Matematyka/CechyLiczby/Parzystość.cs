using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Parzystość : OpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public override string ReprezentacjaTekstowa => "parzysta";

        public override bool Zwróć(double x) => x%2 == 0;
    }
}