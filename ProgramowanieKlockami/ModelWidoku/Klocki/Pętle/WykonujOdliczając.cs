using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonujOdliczając : KlocekPionowyZZawartością, IPętla
    {
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
            kopia.Do[0] = (KlocekZwracającyWartość) Do[0]?.Clone();
            kopia.Od[0] = (KlocekZwracającyWartość) Od[0]?.Clone();
            kopia.Interwał[0] = (KlocekZwracającyWartość) Interwał[0]?.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość od = Od[0];
            KlocekZwracającyWartość @do = Do[0];
            KlocekZwracającyWartość interwał = Interwał[0];

            if ((WybranaZmienna != null) && (od != null) && (@do != null) && (interwał != null))
            {
                double początek = od.Zwróć<double>();
                double koniec = @do.Zwróć<double>();
                double okres = interwał.Zwróć<double>();
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
        }

        private static bool SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej(double a, double b) => a >= b;
        private static bool SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej(double a, double b) => a <= b;
    }
}