using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Dodatniość : OpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public override string ReprezentacjaTekstowa => "dodatnia";

        public override bool Zwróć(double x) => x > 0;
    }
}