using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Napis : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Napis";
        public override string Opis => "Zwraca literę, słowo lub linię tekstu.";
        public override Type ZwracanyTyp => typeof(string);

        public string Treść { get; set; }

        public Napis()
        {
            Treść = string.Empty;
        }

        public override object Zwróć()
        {
            return Treść;
        }
    }
}