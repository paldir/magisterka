using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Całkowitość : IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public string ReprezentacjaTekstowa => "całkowita";

        public bool Zwróć(double x) => x%1 == 0;
    }
}