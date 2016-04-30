using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Ustaw zmienną";
        public override string Opis => "Ustawia zmiennej wybraną wartość";
        public override Brush Kolor => Kolory.Zmienne;
    }
}