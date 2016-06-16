using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class FunkcjaMatematyczna : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Funkcja matematyczna";
        public override string Opis => "Zwraca wartość wybranej funkcji matematycznej.";

        public IFunkcjaMatematyczna WybranaFunkcjaMatematyczna { get; set; }

        public override object Clone()
        {
            FunkcjaMatematyczna kopia = (FunkcjaMatematyczna) base.Clone();
            kopia.WybranaFunkcjaMatematyczna = WybranaFunkcjaMatematyczna;

            return kopia;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            object wartość = klocekZwracającyWartość?.Zwróć();

            if (wartość is double)
                return WybranaFunkcjaMatematyczna.ObliczWartość((double) wartość);

            return 0;
        }
    }
}