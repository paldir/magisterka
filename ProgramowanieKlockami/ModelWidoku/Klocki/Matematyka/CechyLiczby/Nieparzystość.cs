using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Nieparzystość : OpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public override string ReprezentacjaTekstowa => "nieparzysta";

        public override bool Zwróć(double x) => x%2 == 1;
    }
}