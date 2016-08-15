using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Całkowitość : OpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public override string ReprezentacjaTekstowa => "całkowita";

        public override bool Zwróć(double x) => x%1 == 0;
    }
}