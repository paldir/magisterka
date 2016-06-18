using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Nieparzystość : IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public string ReprezentacjaTekstowa => "nieparzysta";

        public bool Zwróć(double x) => x%2 == 1;
    }
}