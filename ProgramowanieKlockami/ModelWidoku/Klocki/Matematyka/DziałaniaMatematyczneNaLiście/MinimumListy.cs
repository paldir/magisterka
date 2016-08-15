using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MinimumListy : OpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public override string ReprezentacjaTekstowa => "Minimum";

        public override double Zwróć(ZmiennaTypuListowego x) => x.OfType<double>().Concat(new[] {double.MaxValue}).Min();
    }
}