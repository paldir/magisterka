using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Napis : IKlocekZwracającyWartość
    {
        public string Nazwa => "Napis";
        public string Opis => "Zwraca literę, słowo lub linię tekstu.";
        public Brush Kolor => Kolory.Tekst;
    }
}