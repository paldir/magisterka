using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class PodzielnośćLiczbyPrzezLiczbę : KlocekZwracającyWartość
    {
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

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekZwracającyWartość1 = Liczba1[0];
            KlocekZwracającyWartość klocekZwracającyWartość2 = Liczba2[0];

            if ((Liczba1 == null) || (Liczba2 == null))
                return false;

            object liczba1 = klocekZwracającyWartość1.Zwróć();
            object liczba2 = klocekZwracającyWartość2.Zwróć();

            if (!(liczba1 is double) || !(liczba2 is double))
                return false;

            return Math.Abs((double) liczba1%(double) liczba2) < double.Epsilon*2;
        }
    }
}