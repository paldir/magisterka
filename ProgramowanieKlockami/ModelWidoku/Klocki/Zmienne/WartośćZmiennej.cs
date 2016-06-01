using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class WartośćZmiennej : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Zmienne;
        public override string Nazwa => "Wartość zmiennej";
        public override string Opis => "Zwraca wartość wybranej zmiennej.";

        public Zmienna WybranaZmienna { get; set; }

        public override object Zwróć()
        {
            return WybranaZmienna?.Wartość;
        }
    }
}