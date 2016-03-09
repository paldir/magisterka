using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Ustaw zmienną";

        public override string Opis => "Ustawia zmiennej wybraną wartość";

        public override Brush KolorObramowania => Brushes.Black;
    }
}