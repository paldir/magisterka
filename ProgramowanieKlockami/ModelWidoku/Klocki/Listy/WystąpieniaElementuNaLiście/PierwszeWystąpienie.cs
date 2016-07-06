using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class PierwszeWystąpienie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>
    {
        public string ReprezentacjaTekstowa => "pierwsze";

        public double Zwróć(ZmiennaTypuListowego a, object b) => a.IndexOf(b);
    }
}