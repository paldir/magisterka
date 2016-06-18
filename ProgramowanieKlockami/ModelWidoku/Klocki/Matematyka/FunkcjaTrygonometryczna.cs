using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class FunkcjaTrygonometryczna : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, double>
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Wartość funkcji trygonometrycznej";
        public override string Opis => "Zwraca wartość funkcji trygonometrycznej dla podanych stopni.";
    }
}