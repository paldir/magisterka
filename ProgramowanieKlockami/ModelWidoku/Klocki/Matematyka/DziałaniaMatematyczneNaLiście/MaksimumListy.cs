using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class MaksimumListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public string ReprezentacjaTekstowa => "Maksimum";

        public double Zwróć(ZmiennaTypuListowego x) => x.OfType<double>().Concat(new[] {double.MinValue}).Max();
    }
}