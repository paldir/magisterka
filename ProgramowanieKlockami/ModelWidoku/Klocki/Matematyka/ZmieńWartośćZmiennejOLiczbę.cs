namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class ZmieńWartośćZmiennejOLiczbę : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Zmiana wartości zmiennej o liczbę";
        public override string Opis => "Zmienia wartość zmiennej o liczbę";

        public Zmienna WybranaZmienna { get; set; }

        public ZmieńWartośćZmiennejOLiczbę() : base(typeof(double))
        {
            Kolor = Kolory.Matematyka;
        }

        public override object Clone()
        {
            ZmieńWartośćZmiennejOLiczbę kopia = (ZmieńWartośćZmiennejOLiczbę) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            base.Wykonaj();

            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((klocekZwracającyWartość != null) && (WybranaZmienna != null))
            {
                object wartośćZmiennej = WybranaZmienna.Wartość;
                double wartość = klocekZwracającyWartość.Zwróć<double>();

                if (wartośćZmiennej is double)
                    WybranaZmienna.Wartość = (double) wartośćZmiennej + wartość;
            }
        }
    }
}