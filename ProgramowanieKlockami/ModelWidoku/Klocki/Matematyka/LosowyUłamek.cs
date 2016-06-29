using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class LosowyUłamek : KlocekZwracającyWartość
    {
        private static readonly Random Los;

        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Losowy ułamek";
        public override string Opis => "Zwraca losowy ułamek pomiędzy 0 a 1.";
        public override Type ZwracanyTyp => typeof(double);

        static LosowyUłamek()
        {
            Los = new Random();
        }

        protected override object ZwróćNiebezpiecznie() => Los.NextDouble();
    }
}