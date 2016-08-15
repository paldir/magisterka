using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji
{
    public class ObcinanieSpacjiZLewejStrony : OpcjaZwracającaWartośćNaPodstawieParametru<object, object>
    {
        public override string ReprezentacjaTekstowa => "z lewej strony";

        public override object Zwróć(object x) => x.ToString().TrimStart();
    }
}