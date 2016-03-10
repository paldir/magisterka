using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Napis : KlocekZwracającyWartość
    {
        public override string Nazwa => "Napis";

        public override string Opis => "Zwraca literę, słowo lub linię tekstu.";

        public override Brush KolorObramowania => Kolory.Tekst;
    }
}