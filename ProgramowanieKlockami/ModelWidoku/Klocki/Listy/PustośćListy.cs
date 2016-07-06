using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustośćListy : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista};

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Sprawdzenie pustości listy";
        public override string Opis => "Zwraca prawdę, jeśli lista jest pusta.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }

        public PustośćListy()
        {
            Lista = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(ZmiennaTypuListowego));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return Lista.Zwróć<ZmiennaTypuListowego>().Count == 0;
        }
    }
}