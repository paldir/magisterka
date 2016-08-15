using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście
{
    public class PierwszeWystąpienie : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>
    {
        public override string ReprezentacjaTekstowa => "pierwsze";

        public override double Zwróć(ZmiennaTypuListowego a, object b) => a.IndexOf(b);
    }
}