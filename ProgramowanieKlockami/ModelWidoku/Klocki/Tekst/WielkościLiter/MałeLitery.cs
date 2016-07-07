using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.WielkościLiter
{
    public class MałeLitery : IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public string ReprezentacjaTekstowa => "małe";

        public object Zwróć(object x) => x.ToString().ToLower();
    }
}