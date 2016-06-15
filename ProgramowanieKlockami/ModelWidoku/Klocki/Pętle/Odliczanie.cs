using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    [Pętla]
    public class Odliczanie : KlocekPionowyZZawartością
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Pętla odliczająca";
        public override string Opis => "Za pomocą zmiennej odlicza od wartości początkowej do końcowej dodając stałą liczbę. Każda iteracja powoduje wykonanie instrukcji.";

        public ObservableCollection<KlocekZwracającyWartość> Do { get; }
        public ObservableCollection<KlocekZwracającyWartość> Od { get; }
        public ObservableCollection<KlocekZwracającyWartość> Interwał { get; }

        public Zmienna WybranaZmienna { get; set; }

        public Odliczanie()
        {
            Do = new ObservableCollection<KlocekZwracającyWartość> {null};
            Od = new ObservableCollection<KlocekZwracającyWartość> {null};
            Interwał = new ObservableCollection<KlocekZwracającyWartość> {null};
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
                        if (PrzerwanieWykonywania)
                        {
                            ZresetujFlagęPrzerwaniaWykonywania(this);

                            break;
                        }
                        else
                        {
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