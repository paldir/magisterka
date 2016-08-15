using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Prawda : OpcjaZwracającaWartość<bool>
    {
        public override string ReprezentacjaTekstowa => "prawda";
        public override bool Wartość => true;
    }
}