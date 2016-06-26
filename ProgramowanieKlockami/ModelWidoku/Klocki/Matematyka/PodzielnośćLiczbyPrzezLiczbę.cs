using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class PodzielnośćLiczbyPrzezLiczbę : KlocekZwracającyWartość
    {
        protected override WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące => new[] {Liczba1, Liczba2};

        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Podzielność liczby przez liczbę";
        public override string Opis => "Zwraca prawdę, jeśli pierwsza liczba jest podzielna przez drugą.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćKlockaPrzyjmującegoWartość Liczba1 { get; }
        public WartośćKlockaPrzyjmującegoWartość Liczba2 { get; }

        public PodzielnośćLiczbyPrzezLiczbę()
        {
            Liczba1 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
            Liczba2 = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return Math.Abs(Liczba1.Zwróć<double>()%Liczba2.Zwróć<double>()) < double.Epsilon*2;
        }
    }
}