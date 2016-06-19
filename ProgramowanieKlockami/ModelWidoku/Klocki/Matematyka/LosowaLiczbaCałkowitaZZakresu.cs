using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class LosowaLiczbaCałkowitaZZakresu : KlocekZwracającyWartość
    {
        private static readonly Random Los;

        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Liczba losowa z zakresu";
        public override string Opis => "Zwraca liczbę losową z zakresu";
        public override Type ZwracanyTyp => typeof(double);

        public WartośćKlockaPrzyjmującegoWartość Liczba1 { get; }
        public WartośćKlockaPrzyjmującegoWartość Liczba2 { get; }

        static LosowaLiczbaCałkowitaZZakresu()
        {
            Los = new Random();
        }

        public LosowaLiczbaCałkowitaZZakresu()
        {
            Liczba1 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
            Liczba2 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekZwracającyWartość1 = Liczba1[0];
            KlocekZwracającyWartość klocekZwracającyWartość2 = Liczba2[0];

            if ((klocekZwracającyWartość1 == null) || (klocekZwracającyWartość2 == null))
                return 0;

            object wartość1 = klocekZwracającyWartość1.Zwróć();
            object wartość2 = klocekZwracającyWartość2.Zwróć();

            if (!(wartość1 is double) || !(wartość2 is double))
                return 0;

            int liczba1 = (int) Math.Ceiling((double) wartość1);
            int liczba2 = (int) Math.Ceiling((double) wartość2);

            if (liczba1 > liczba2)
            {
                int tmp = liczba1;
                liczba1 = liczba2;
                liczba2 = tmp;
            }

            return Los.Next(liczba1, liczba2);
        }
    }
}