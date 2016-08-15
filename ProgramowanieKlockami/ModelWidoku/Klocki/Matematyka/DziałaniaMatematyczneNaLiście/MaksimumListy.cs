using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MaksimumListy : OpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public override string ReprezentacjaTekstowa => "Maksimum";

        public override double Zwróć(ZmiennaTypuListowego x) => x.OfType<double>().Concat(new[] {double.MinValue}).Max();
    }
}