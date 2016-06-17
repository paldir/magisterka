using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Alternatywa : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool>
    {
        public string ReprezentacjaTekstowa => "lub";

        public bool Zwróć(bool a, bool b) => a || b;
    }
}