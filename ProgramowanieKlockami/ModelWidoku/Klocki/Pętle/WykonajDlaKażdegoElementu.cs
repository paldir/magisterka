namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonajDlaKażdegoElementu : KlocekPionowyZZawartościąPrzyjmującyWartość, IPętla
    {
        public override string Nazwa => "Dla każdego elementu listy";
        public override string Opis => "Ustawia wartość wybranej zmiennej na kolejne elementy listy.";

        public PowódSkoku PowódSkoku { get; set; }
        public Zmienna WybranaZmienna { get; set; }

        public WykonajDlaKażdegoElementu() : base(typeof(ZmiennaTypuListowego))
        {
            Kolor = Kolory.Pętle;
        }

        public override object Clone()
        {
            WykonajDlaKażdegoElementu kopia = (WykonajDlaKażdegoElementu) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            SprawdźPoprawnośćKlockówKonfigurujących();
            SprawdźPoprawnośćZmiennej(WybranaZmienna, null);

            if (Błąd)
                return;

            ZmiennaTypuListowego lista = Wartość.Zwróć<ZmiennaTypuListowego>();

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