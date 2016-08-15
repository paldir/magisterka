using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class OstatnieWystąpienie : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>
    {
        public override string ReprezentacjaTekstowa => "ostatnie";

        public override double Zwróć(ZmiennaTypuListowego a, object b) => a.ToList().LastIndexOf(b);
    }
}