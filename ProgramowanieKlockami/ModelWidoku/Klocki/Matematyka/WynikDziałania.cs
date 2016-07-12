using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WynikDziałania : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<double, double, double>
    {
        public override string Nazwa => "Wynik działania";
        public override string Opis => "Zwraca wynik działania matematycznego.";

        public WynikDziałania()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}