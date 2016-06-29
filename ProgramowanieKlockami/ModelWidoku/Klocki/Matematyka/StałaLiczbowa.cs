using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class StałaLiczbowa : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Stała liczbowa";
        public override string Opis => "Zwraca liczbę.";
        public override Type ZwracanyTyp => typeof(double);

        public double Liczba { get; set; }

        protected override object ZwróćNiebezpiecznie() => Liczba;
    }
}