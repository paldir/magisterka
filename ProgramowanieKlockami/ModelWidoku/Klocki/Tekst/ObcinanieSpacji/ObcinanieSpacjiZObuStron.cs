using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZObuStron : OpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public override string ReprezentacjaTekstowa => "z obu stron";

        public override object Zwróć(object x) => x.ToString().Trim();
    }
}