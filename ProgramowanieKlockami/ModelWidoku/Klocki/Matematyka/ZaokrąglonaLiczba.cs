using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class ZaokrąglonaLiczba : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, double>
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Zaokrąglona liczba";
        public override string Opis => "Zwraca liczbę zaokrągloną zgodnie z wybraną zasadą.";
    }
}