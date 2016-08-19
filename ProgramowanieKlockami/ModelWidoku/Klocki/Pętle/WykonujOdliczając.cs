using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonujOdliczając : KlocekPionowyZZawartością, IPętla
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Od, Do, Interwał};

        public override string Nazwa => "Pętla odliczająca";
        public override string Opis => "Za pomocą zmiennej odlicza od wartości początkowej do końcowej dodając stałą liczbę. Każda iteracja powoduje wykonanie instrukcji.";

        public WartośćWewnętrznegoKlockaZwracającegoWartość Do { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Od { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Interwał { get; }

        public PowódSkoku PowódSkoku { get; set; }
        public Zmienna WybranaZmienna { get; set; }

        public WykonujOdliczając()
        {
            Do = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Pętle;
            Od = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Interwał = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        public override object Clone()
        {
            WykonujOdliczając kopia = (WykonujOdliczając) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            SprawdźPoprawnośćKlockówKonfigurujących();
            SprawdźPoprawnośćZmiennej(WybranaZmienna, null);

            if (Błąd)
                return;

            double początek = Od.Zwróć<double>(false);
            double koniec = Do.Zwróć<double>(false);
            double okres = Interwał.Zwróć<double>(false);
            Func<double, double, bool> funkcjaPorównująca;

            if (okres < 0)
                funkcjaPorównująca = SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej;
            else if (okres > 0)
                funkcjaPorównująca = SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej;
            else
                funkcjaPorównująca = (a, b) => false;

            for (double i = początek; funkcjaPorównująca(i, koniec); i += okres)
            {
                ZresetujRekurencyjnieFlagęSkokuWPętli(this);

                if (PowódSkoku == PowódSkoku.PrzerwaniePętli)
                {
                    PowódSkoku = PowódSkoku.Brak;

                    break;
                }

                PowódSkoku = PowódSkoku.Brak;
                WybranaZmienna.Wartość = i;

                base.Wykonaj();
            }
        }

        private static bool SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej(double a, double b) => a > b;
        private static bool SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej(double a, double b) => a < b;
    }
}