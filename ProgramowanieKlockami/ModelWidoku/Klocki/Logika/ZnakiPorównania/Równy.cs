using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public class Równy : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable>
    {
        public string ReprezentacjaTekstowa => "==";

        public bool Zwróć(IComparable x, IComparable y) => x.CompareTo(y) == 0;
    }
}