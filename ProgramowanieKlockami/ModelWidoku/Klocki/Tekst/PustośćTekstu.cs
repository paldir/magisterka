using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class PustośćTekstu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Tekst};

        public override string Nazwa => "Pustość tekstu";
        public override string Opis => "Zwraca prawdę, jeśli liczba znaków w tekście wynosi 0.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Tekst { get; }

        public PustośćTekstu()
        {
            Kolor = Kolory.Tekst;
            Tekst = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            string tekst = Tekst.Zwróć<object>(sprawdzanieBłędów).ToString();

            return string.IsNullOrEmpty(tekst);
        }

        public override object Clone()
        {
            PustośćTekstu kopia = (PustośćTekstu) base.Clone();

            return kopia;
        }
    }
}