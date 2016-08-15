using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class SumaListy : OpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public override string ReprezentacjaTekstowa => "Suma";

        public override double Zwróć(ZmiennaTypuListowego x) => x.Where(l => l is double).Sum(l => (double) l);
    }
}