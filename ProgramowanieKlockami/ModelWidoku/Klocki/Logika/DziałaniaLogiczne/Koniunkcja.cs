using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Koniunkcja : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool, bool>
    {
        public override string ReprezentacjaTekstowa => "i";

        public override bool Zwróć(bool a, bool b) => a && b;
    }
}