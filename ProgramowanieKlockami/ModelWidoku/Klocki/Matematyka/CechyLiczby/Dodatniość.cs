using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Dodatniość : IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public string ReprezentacjaTekstowa => "dodatnia";

        public bool Zwróć(double x) => x > 0;
    }
}