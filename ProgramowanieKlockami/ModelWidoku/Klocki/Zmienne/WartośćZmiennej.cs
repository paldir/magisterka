using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class WartośćZmiennej : IKlocekZwracającyWartość
    {
        public string Nazwa => "Wartość zmiennej";
        public string Opis => "Zwraca wartość wybranej zmiennej.";
        public Brush Kolor => Kolory.Zmienne;
    }
}