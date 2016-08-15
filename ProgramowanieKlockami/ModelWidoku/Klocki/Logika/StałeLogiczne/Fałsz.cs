using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Fałsz : OpcjaZwracającaWartość<bool>
    {
        public override string ReprezentacjaTekstowa => "fałsz";
        public override bool Wartość => false;
    }
}