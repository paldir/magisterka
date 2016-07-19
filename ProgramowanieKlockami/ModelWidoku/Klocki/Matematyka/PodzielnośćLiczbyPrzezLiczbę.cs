using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class PodzielnośćLiczbyPrzezLiczbę : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Liczba1, Liczba2};

        public override string Nazwa => "Podzielność liczby przez liczbę";
        public override string Opis => "Zwraca prawdę, jeśli pierwsza liczba jest podzielna przez drugą.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba1 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba2 { get; }

        public PodzielnośćLiczbyPrzezLiczbę()
        {
            Kolor = Kolory.Matematyka;
            Liczba1 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Liczba2 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return Math.Abs(Liczba1.Zwróć<double>()%Liczba2.Zwróć<double>()) < double.Epsilon*2;
        }

        public override object Clone()
        {
            PodzielnośćLiczbyPrzezLiczbę kopia = (PodzielnośćLiczbyPrzezLiczbę) base.Clone();
            kopia.Liczba1[0] = (KlocekZwracającyWartość) Liczba1[0]?.Clone();
            kopia.Liczba2[0] = (KlocekZwracającyWartość) Liczba2[0]?.Clone();

            return kopia;
        }
    }
}