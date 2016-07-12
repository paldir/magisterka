using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WystępowanieCechyLiczby : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<bool, double>
    {
        public override string Nazwa => "Występowanie cechy liczby";
        public override string Opis => "Zwraca prawdę, jeśli liczba posiada wybraną cechę.";

        public WystępowanieCechyLiczby()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}