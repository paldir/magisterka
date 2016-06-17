using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Zmienne;
        public override string Nazwa => "Ustaw zmienną";
        public override string Opis => "Ustawia zmiennej wybraną wartość";

        public Zmienna WybranaZmienna { get; set; }

        public UstawZmienną() : base(typeof(object))
        {
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość wartość = Wartość[0];

            if ((WybranaZmienna != null) && (wartość != null))
                WybranaZmienna.Wartość = wartość.Zwróć();
        }
    }
}