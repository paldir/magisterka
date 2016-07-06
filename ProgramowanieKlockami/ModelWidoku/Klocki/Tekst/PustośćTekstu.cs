using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class PustośćTekstu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Tekst};

        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Pustość tekstu";
        public override string Opis => "Zwraca prawdę, jeśli liczba znaków w tekście wynosi 0.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Tekst { get; }

        public PustośćTekstu()
        {
            Tekst = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            string tekst = Tekst.Zwróć<object>().ToString();

            return string.IsNullOrEmpty(tekst);
        }
    }
}