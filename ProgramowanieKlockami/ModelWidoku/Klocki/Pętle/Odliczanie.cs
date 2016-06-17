using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class Odliczanie : KlocekPionowyZZawartością, IPętla
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Pętla odliczająca";
        public override string Opis => "Za pomocą zmiennej odlicza od wartości początkowej do końcowej dodając stałą liczbę. Każda iteracja powoduje wykonanie instrukcji.";

        public WartośćKlockaPrzyjmującegoWartość Do { get; }
        public WartośćKlockaPrzyjmującegoWartość Od { get; }
        public WartośćKlockaPrzyjmującegoWartość Interwał { get; }

        public PowódSkoku PowódSkoku { get; set; }
        public Zmienna WybranaZmienna { get; set; }

        public Odliczanie()
        {
            Do = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
            Od = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
            Interwał = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość od = Od[0];
            KlocekZwracającyWartość @do = Do[0];
            KlocekZwracającyWartość interwał = Interwał[0];

            if ((od != null) && (@do != null) && (interwał != null))
            {
                object początek = od.Zwróć();
                object koniec = @do.Zwróć();
                object okres = interwał.Zwróć();

                if (początek is double && koniec is double && okres is double)
                {
                    double iterator = (double) okres;
                    Func<double, double, bool> funkcjaPorównująca;

                    if (iterator < 0)
                        funkcjaPorównująca = SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej;
                    else if (iterator > 0)
                        funkcjaPorównująca = SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej;
                    else
                        funkcjaPorównująca = (a, b) => false;

                    for (double i = (double) początek; funkcjaPorównująca(i, (double) koniec); i += iterator)
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
        }

        private static bool SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej(double a, double b) => a >= b;
        private static bool SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej(double a, double b) => a <= b;
    }
}