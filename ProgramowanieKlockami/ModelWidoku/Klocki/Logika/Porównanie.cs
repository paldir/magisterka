using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override string Nazwa => "Porównanie";

        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public override Brush KolorObramowania => Kolory.Logika;

        public KlocekZwracającyWartość WartośćPierwsza { get; set; }
    }
}