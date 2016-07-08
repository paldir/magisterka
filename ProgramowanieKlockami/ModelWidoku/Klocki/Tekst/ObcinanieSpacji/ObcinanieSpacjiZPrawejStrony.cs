using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZPrawejStrony : IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public string ReprezentacjaTekstowa => "z prawej strony";

        public object Zwróć(object x) => x.ToString().TrimEnd();
    }
}