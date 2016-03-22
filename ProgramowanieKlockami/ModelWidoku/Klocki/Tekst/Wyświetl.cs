using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Wyświetl : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Wyświetl";

        public override string Opis => "Wyświetla tekst, liczbę lub inną wartość.";

        public override Brush Kolor => Kolory.Tekst;
    }
}