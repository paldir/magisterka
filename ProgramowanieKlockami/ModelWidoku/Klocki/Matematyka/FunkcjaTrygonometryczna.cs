using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class FunkcjaTrygonometryczna : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, double>
    {
        public override string Nazwa => "Wartość funkcji trygonometrycznej";
        public override string Opis => "Zwraca wartość funkcji trygonometrycznej dla podanych stopni.";

        public FunkcjaTrygonometryczna()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}