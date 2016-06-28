using System.Collections.Generic;
using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class SumaListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, List<object>>
    {
        public string ReprezentacjaTekstowa => "Suma";

        public double Zwróć(List<object> x) => x.Where(l => l is double).Sum(l => (double) l);
    }
}