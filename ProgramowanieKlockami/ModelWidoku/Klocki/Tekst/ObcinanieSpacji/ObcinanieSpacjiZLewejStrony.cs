using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZLewejStrony : IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public string ReprezentacjaTekstowa => "z lewej strony";

        public object Zwróć(object x) => x.ToString().TrimStart();
    }
}