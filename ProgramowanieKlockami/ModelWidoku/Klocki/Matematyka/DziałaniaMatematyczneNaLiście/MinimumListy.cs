using System.Collections.Generic;
using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MinimumListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, List<object>>
    {
        public string ReprezentacjaTekstowa => "Minimum";

        public double Zwróć(List<object> x) => x.OfType<double>().Concat(new[] {double.MaxValue}).Min();
    }
}