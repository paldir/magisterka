using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonajDlaKażdegoElementu : KlocekPionowyZZawartościąPrzyjmującyWartość, IPętla
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Dla każdego elementu listy";
        public override string Opis => "Ustawia wartość wybranej zmiennej na kolejne elementy listy.";

        public PowódSkoku PowódSkoku { get; set; }
        public Zmienna WybranaZmienna { get; set; }

        public WykonajDlaKażdegoElementu() : base(typeof(List<object>))
        {
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((klocekZwracającyWartość != null) && (WybranaZmienna != null))
            {
                List<object> lista = klocekZwracającyWartość.Zwróć<List<object>>();

                foreach (object element in lista)
                {
                    ZresetujRekurencyjnieFlagęSkokuWPętli(this);

                    if (PowódSkoku == PowódSkoku.PrzerwaniePętli)
                    {
                        PowódSkoku = PowódSkoku.Brak;

                        break;
                    }

                    PowódSkoku = PowódSkoku.Brak;
                    WybranaZmienna.Wartość = element;

                    base.Wykonaj();
                }
            }
        }
    }
}