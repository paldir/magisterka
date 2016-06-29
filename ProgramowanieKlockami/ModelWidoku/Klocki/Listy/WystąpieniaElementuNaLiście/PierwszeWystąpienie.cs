using System.Collections.Generic;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class PierwszeWystąpienie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, List<object>, object>
    {
        public string ReprezentacjaTekstowa => "pierwsze";

        public double Zwróć(List<object> a, object b) => a.IndexOf(b);
    }
}