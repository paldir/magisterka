using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Wyświetl : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Wyświetl";
        public override string Opis => "Wyświetla tekst, liczbę lub inną wartość.";

        public Konsola Konsola { get; set; }

        public Wyświetl() : base(typeof(object))
        {
        }

        public override object Clone()
        {
            Wyświetl nowyKlocek = (Wyświetl) base.Clone();
            nowyKlocek.Konsola = Konsola;

            return nowyKlocek;
        }

        public override void Wykonaj()
        {
            object wartość = Wartość[0]?.Zwróć();

            if (wartość != null)
                Konsola.DodajLinię(wartość.ToString());
        }
    }
}