using System;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WynikDziałania : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Wynik działania";
        public override string Opis => "Zwraca wynik działania matematycznego.";
        public override Type ZwracanyTyp => typeof(double);

        public WartośćKlockaPrzyjmującegoWartość Wartość1 { get; set; }
        public WartośćKlockaPrzyjmującegoWartość Wartość2 { get; set; }
        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double> WybraneDziałanieMatematyczne { get; set; }

        public WynikDziałania()
        {
            Wartość1 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
            Wartość2 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
        }

        public override object Clone()
        {
            WynikDziałania kopia = (WynikDziałania) base.Clone();
            kopia.WybraneDziałanieMatematyczne = WybraneDziałanieMatematyczne;

            return kopia;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość1 = Wartość1[0];
            KlocekZwracającyWartość wartość2 = Wartość2[0];

            if ((wartość1 == null) || (wartość2 == null))
                return 0;

            object liczba1 = wartość1.Zwróć();
            object liczba2 = wartość2.Zwróć();

            if (!(liczba1 is double) || !(liczba2 is double))
                return 0;

            return WybraneDziałanieMatematyczne.Zwróć((double) liczba1, (double) liczba2);
        }
    }
}