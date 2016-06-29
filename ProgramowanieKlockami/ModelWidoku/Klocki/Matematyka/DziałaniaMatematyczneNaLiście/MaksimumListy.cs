using System.Collections.Generic;
using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MaksimumListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, List<object>>
    {
        public string ReprezentacjaTekstowa => "Maksimum";

        public double Zwróć(List<object> x) => x.OfType<double>().Concat(new[] {double.MinValue}).Max();
    }
}