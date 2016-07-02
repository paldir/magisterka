using System.Collections.Generic;
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
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];
            object wartość = klocekZwracającyWartość?.Zwróć<object>();

            if (wartość != null)
            {
                if (wartość is List<object>)
                    wartość = string.Join(", ", (List<object>) wartość);

                Konsola.DodajLinię(wartość.ToString());
            }
        }
    }
}