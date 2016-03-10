using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class WartośćZmiennej : KlocekZwracającyWartość
    {
        public override string Nazwa => "Wartość zmiennej";

        public override string Opis => "Zwraca wartość wybranej zmiennej.";

        public override Brush KolorObramowania => Kolory.Zmienne;
    }
}
