using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby
{
    public class Ujemność : OpcjaZwracającaWartośćNaPodstawieParametru<bool, double>
    {
        public override string ReprezentacjaTekstowa => "ujemna";

        public override bool Zwróć(double x) => x < 0;
    }
}