using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class FunkcjaMatematyczna : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, double>
    {
        public override string Nazwa => "Funkcja matematyczna";
        public override string Opis => "Zwraca wartość wybranej funkcji matematycznej.";

        public FunkcjaMatematyczna()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}