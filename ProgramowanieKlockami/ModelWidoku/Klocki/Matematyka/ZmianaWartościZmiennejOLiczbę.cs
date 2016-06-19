using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class ZmianaWartościZmiennejOLiczbę : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Zmiana wartości zmiennej o liczbę";
        public override string Opis => "Zmienia wartość zmiennej o liczbę";

        public Zmienna WybranaZmienna { get; set; }

        public ZmianaWartościZmiennejOLiczbę() : base(typeof(double))
        {
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((klocekZwracającyWartość != null) && (WybranaZmienna != null))
            {
                object wartośćZmiennej = WybranaZmienna.Wartość;
                object wartość = klocekZwracającyWartość.Zwróć();

                if (wartość is double && wartośćZmiennej is double)
                    WybranaZmienna.Wartość = (double) wartośćZmiennej + (double) wartość;
            }
        }
    }
}