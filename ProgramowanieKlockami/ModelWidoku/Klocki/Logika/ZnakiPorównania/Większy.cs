using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public class Większy : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable, IComparable>
    {
        public string ReprezentacjaTekstowa => ">";

        public bool Zwróć(IComparable x, IComparable y) => x.CompareTo(y) > 0;
    }
}