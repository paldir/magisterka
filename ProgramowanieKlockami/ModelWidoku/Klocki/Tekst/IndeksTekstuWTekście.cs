using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class IndeksTekstuWTekście : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<double, object, object>
    {
        public override string Nazwa => "Indeks tekstu w tekście";
        public override string Opis => "Zwraca indeks pierwszego/ostatniego wystąpienia tekstu w tekście";

        public IndeksTekstuWTekście()
        {
            Kolor = Kolory.Tekst;
        }
    }
}