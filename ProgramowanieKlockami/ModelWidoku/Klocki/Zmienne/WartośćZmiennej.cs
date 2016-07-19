using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class WartośćZmiennej : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Wartość zmiennej";
        public override string Opis => "Zwraca wartość wybranej zmiennej.";
        public override Type ZwracanyTyp => null;

        public Zmienna WybranaZmienna { get; set; }

        public WartośćZmiennej()
        {
            Kolor = Kolory.Zmienne;
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaZmienna?.Wartość;
        }

        public override object Clone()
        {
            WartośćZmiennej kopia = (WartośćZmiennej) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }
    }
}