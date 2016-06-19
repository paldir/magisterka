using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class LosowyUłamek : KlocekZwracającyWartość
    {
        private static readonly Random Los;

        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Losowy ułamek";
        public override string Opis => "Zwraca losowy ułamek pomiędzy 0 a 1.";
        public override Type ZwracanyTyp => typeof(double);

        static LosowyUłamek()
        {
            Los = new Random();
        }

        public override object Zwróć() => Los.NextDouble();
    }
}