using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public class Nierówny : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, object, object>
    {
        public override string ReprezentacjaTekstowa => "!=";

        public override bool Zwróć(object x, object y) => ((IComparable)x).CompareTo(y) != 0;
    }
}