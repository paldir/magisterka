using System;
using System.Collections.ObjectModel;
using System.Windows;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonujOdliczając : KlocekPionowyZZawartością, IPętla
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

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
            object obiektOd = Od[0]?.Zwróć<object>();
            object obiektDo = Do[0]?.Zwróć<object>();
            object obiektInterwału = Interwał[0]?.Zwróć<object>();
            Błędy = new ObservableCollection<BłądKlocka>();
            Błąd = false;
            double od;
            double @do;
            double interwał;

            if (obiektOd is double)
                od = (double) obiektOd;
            else
            {
                Błąd = true;
                od = 0;

                Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(double), obiektOd?.GetType())); });
            }

            if (obiektDo is double)
                @do = (double) obiektDo;
            else
            {
                Błąd = true;
                @do = 0;

                Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(double), obiektDo?.GetType())); });
            }

            if (obiektInterwału is double)
                interwał = (double) obiektInterwału;
            else
            {
                Błąd = true;
                interwał = 0;

                Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(double), obiektInterwału?.GetType())); });
            }

            if (WybranaZmienna == null)
            {
                Błąd = true;

                Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądZwiązanyZBrakiemWyboruZmiennej()); });

                return;
            }

            double początek = od;
            double koniec = @do;
            double okres = interwał;
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

        private static bool SprawdźCzyPierwszaLiczbaJestWiększaRównaOdDrugiej(double a, double b) => a >= b;
        private static bool SprawdźCzyPierwszaLiczbaJestMniejszaRównaOdDrugiej(double a, double b) => a <= b;
    }
}