using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override string Nazwa => "Porównnie";

        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public override Brush KolorObramowania => Brushes.Black;
    }
}
