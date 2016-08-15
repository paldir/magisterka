using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZPrawejStrony : OpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public override string ReprezentacjaTekstowa => "z prawej strony";

        public override object Zwróć(object x) => x.ToString().TrimEnd();
    }
}