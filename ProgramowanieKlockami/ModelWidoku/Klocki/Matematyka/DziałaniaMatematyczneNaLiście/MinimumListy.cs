using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MinimumListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public string ReprezentacjaTekstowa => "Minimum";

        public double Zwróć(ZmiennaTypuListowego x) => x.OfType<double>().Concat(new[] {double.MaxValue}).Min();
    }
}