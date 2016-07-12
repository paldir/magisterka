using System;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaPowtórzonegoElementu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Element, Liczba};

        public override string Nazwa => "Lista złożona z powtórzonego elementu";
        public override string Opis => "Tworzy listę zawierającą wybrany element powtórzony określoną liczbę razy.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Element { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba { get; }

        public ListaPowtórzonegoElementu()
        {
            Element = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
            Kolor = Kolory.Listy;
            Liczba = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return new ZmiennaTypuListowego(Enumerable.Repeat(Element.Zwróć<object>(), (int) Math.Round(Liczba.Zwróć<double>())));
        }
    }
}