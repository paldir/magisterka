using System.Collections.Generic;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class OstatnieWystąpienie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, List<object>, object>
    {
        public string ReprezentacjaTekstowa => "ostatnie";

        public double Zwróć(List<object> a, object b) => a.LastIndexOf(b);
    }
}