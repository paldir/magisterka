using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class WartośćZmiennej : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Zmienne;
        public override string Nazwa => "Wartość zmiennej";
        public override string Opis => "Zwraca wartość wybranej zmiennej.";
        public override Type ZwracanyTyp => null;

        public Zmienna WybranaZmienna { get; set; }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaZmienna?.Wartość;
        }
    }
}