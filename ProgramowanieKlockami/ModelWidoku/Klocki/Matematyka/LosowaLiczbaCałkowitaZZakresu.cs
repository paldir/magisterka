using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class LosowaLiczbaCałkowitaZZakresu : KlocekZwracającyWartość
    {
        private static readonly Random Los;

        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Liczba1, Liczba2};

        public override string Nazwa => "Liczba losowa z zakresu";
        public override string Opis => "Zwraca liczbę losową z zakresu";
        public override Type ZwracanyTyp => typeof(double);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba1 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba2 { get; }

        static LosowaLiczbaCałkowitaZZakresu()
        {
            Los = new Random();
        }

        public LosowaLiczbaCałkowitaZZakresu()
        {
            Kolor = Kolory.Matematyka;
            Liczba1 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Liczba2 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            int liczba1 = (int) Math.Ceiling(Liczba1.Zwróć<double>(sprawdzanieBłędów));
            int liczba2 = (int) Math.Ceiling(Liczba2.Zwróć<double>(sprawdzanieBłędów));

            if (liczba1 > liczba2)
            {
                int tmp = liczba1;
                liczba1 = liczba2;
                liczba2 = tmp;
            }

            return Convert.ToDouble(Los.Next(liczba1, liczba2));
        }

        public override object Clone()
        {
            LosowaLiczbaCałkowitaZZakresu kopia = (LosowaLiczbaCałkowitaZZakresu) base.Clone();

            return kopia;
        }
    }
}