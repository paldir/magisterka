using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Alternatywa : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool, bool>
    {
        public override string ReprezentacjaTekstowa => "lub";

        public override bool Zwróć(bool a, bool b) => a || b;
    }
}