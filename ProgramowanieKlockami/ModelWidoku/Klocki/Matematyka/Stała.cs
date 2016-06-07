using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class Stała : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Stała";
        public override string Opis => "Zwraca liczbę.";

        public double Liczba { get; set; }

        public override object Zwróć()
        {
            return Liczba;
        }
    }
}