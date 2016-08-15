using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.WielkościLiter
{
    public class WielkieLitery : OpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public override string ReprezentacjaTekstowa => "WIELKIE";

        public override object Zwróć(object x) => x.ToString().ToUpper();
    }
}