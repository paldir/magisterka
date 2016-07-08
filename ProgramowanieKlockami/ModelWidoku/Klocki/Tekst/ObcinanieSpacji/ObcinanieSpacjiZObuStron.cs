using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZObuStron : IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public string ReprezentacjaTekstowa => "z obu stron";

        public object Zwróć(object x) => x.ToString().Trim();
    }
}