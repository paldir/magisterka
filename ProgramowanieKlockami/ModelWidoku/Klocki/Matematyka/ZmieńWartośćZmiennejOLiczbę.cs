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
            SprawdźPoprawnośćKlockówKonfigurujących();
            SprawdźPoprawnośćZmiennej(WybranaZmienna, typeof(double));

            if (Błąd)
                return;

            double wartość = Wartość.Zwróć<double>(false);
            WybranaZmienna.Wartość = (double) WybranaZmienna.Wartość + wartość;
        }
    }
}