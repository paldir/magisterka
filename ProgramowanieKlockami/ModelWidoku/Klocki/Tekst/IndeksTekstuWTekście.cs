using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class IndeksTekstuWTekście : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<double, object, object>
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Indeks tekstu w tekście";
        public override string Opis => "Zwraca indeks pierwszego/ostatniego wystąpienia tekstu w tekście";
    }
}