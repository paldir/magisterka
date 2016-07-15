using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public class Nierówny : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, object, object>
    {
        public string ReprezentacjaTekstowa => "!=";

        public bool Zwróć(object x, object y) => ((IComparable)x).CompareTo(y) != 0;
    }
}