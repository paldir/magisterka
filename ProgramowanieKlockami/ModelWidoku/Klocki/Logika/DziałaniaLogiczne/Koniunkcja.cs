using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Koniunkcja : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool>
    {
        public string ReprezentacjaTekstowa => "i";

        public bool Zwróć(bool a, bool b) => a && b;
    }
}