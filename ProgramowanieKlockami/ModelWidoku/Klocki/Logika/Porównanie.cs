using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : IKlocekZwracającyWartość
    {
        public string Nazwa => "Porównanie";
        public string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";
        public Brush Kolor => Kolory.Logika;
        public IKlocekZwracającyWartość WartośćPierwsza { get; set; }
        public IKlocekZwracającyWartość WartośćDruga { get; set; }
    }
}