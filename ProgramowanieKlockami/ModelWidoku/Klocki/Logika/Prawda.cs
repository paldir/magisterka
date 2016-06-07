using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Prawda : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Prawda";
        public override string Opis => "Zwraca prawdę.";

        public override object Zwróć()
        {
            return true;
        }
    }
}