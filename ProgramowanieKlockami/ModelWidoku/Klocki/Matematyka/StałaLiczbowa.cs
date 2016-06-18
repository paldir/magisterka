using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class StałaLiczbowa : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Stała liczbowa";
        public override string Opis => "Zwraca liczbę.";
        public override Type ZwracanyTyp => typeof(double);

        public double Liczba { get; set; }

        public override object Zwróć()
        {
            return Liczba;
        }
    }
}