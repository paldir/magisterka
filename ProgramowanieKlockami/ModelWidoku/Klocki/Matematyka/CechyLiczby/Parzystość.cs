using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Parzystość : IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public string ReprezentacjaTekstowa => "parzysta";

        public bool Zwróć(double x) => x%2 == 0;
    }
}