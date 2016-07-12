using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class StałaMatematyczna : KlocekZwracającyWartośćNaPodstawieOpcji<double>
    {
        public override string Nazwa => "Stała matematyczna";
        public override string Opis => "Zwraca jedną z popularnych stałych matematycznych";

        public StałaMatematyczna()
        {
            Kolor = Kolory.Matematyka;
        }
    }
}