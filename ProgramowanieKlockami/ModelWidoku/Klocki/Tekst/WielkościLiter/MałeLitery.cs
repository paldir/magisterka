using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.WielkościLiter
{
    public class MałeLitery : OpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public override string ReprezentacjaTekstowa => "małe";

        public override object Zwróć(object x) => x.ToString().ToLower();
    }
}