using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WynikDziałaniaMatematycznegoNaLiście : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, ZmiennaTypuListowego>
    {
        public override string Nazwa => "Działanie matematyczne na liście";
        public override string Opis => "Zwraca wynik działania matematycznego wykonanego na wszystkich elementach listy";

        public WynikDziałaniaMatematycznegoNaLiście()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}