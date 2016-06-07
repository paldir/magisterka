using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Fałsz : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Fałsz";
        public override string Opis => "Zwraca fałsz.";

        public override object Zwróć()
        {
            return false;
        }
    }
}