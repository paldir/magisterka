using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class OstatnieWystąpienie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>
    {
        public string ReprezentacjaTekstowa => "ostatnie";

        public double Zwróć(ZmiennaTypuListowego a, object b) => a.LastIndexOf(b);
    }
}