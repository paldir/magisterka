using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Zmienne;
        public override string Nazwa => "Ustaw zmienną";
        public override string Opis => "Ustawia zmiennej wybraną wartość";

        public Zmienna WybranaZmienna { get; set; }

        public override void Wykonaj()
        {
            if ((WybranaZmienna != null) && (Wartość != null))
                WybranaZmienna.Wartość = Wartość[0].Zwróć();
        }
    }
}