using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Koniunkcja : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool, bool>
    {
        public string ReprezentacjaTekstowa => "i";

        public bool Zwróć(bool a, bool b) => a && b;
    }
}