using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class SumaListy : IOpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public string ReprezentacjaTekstowa => "Suma";

        public double Zwróć(ZmiennaTypuListowego x) => x.Where(l => l is double).Sum(l => (double) l);
    }
}