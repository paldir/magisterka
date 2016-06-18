using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Ujemność : IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public string ReprezentacjaTekstowa => "ujemna";

        public bool Zwróć(double x) => x < 0;
    }
}