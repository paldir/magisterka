using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.WielkościLiter
{
    public class WielkieLitery : IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public string ReprezentacjaTekstowa => "WIELKIE";

        public object Zwróć(object x) => x.ToString().ToUpper();
    }
}