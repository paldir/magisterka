using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustaLista : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Pusta lista";
        public override string Opis => "Tworzy pustą listę.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        protected override object ZwróćNiebezpiecznie()
        {
            return new ZmiennaTypuListowego();
        }
    }
}