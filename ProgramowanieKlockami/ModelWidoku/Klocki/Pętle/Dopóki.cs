using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    [Pętla]
    public class Dopóki : KlocekPionowyZZawartościąPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Pętla dopóki";
        public override string Opis => "Dopóki wartość jest prawdziwa, wykonuje instrukcje.";

        public override void Wykonaj()
        {
            KlocekZwracającyWartość wartość = Wartość[0];

            if (wartość?.Zwróć() is bool)
                while ((bool) wartość.Zwróć())
                    if (PrzerwanieWykonywania)
                    {
                        ZresetujFlagęPrzerwaniaWykonywania(this);

                        break;
                    }
                    else
                        base.Wykonaj();
        }
    }
}