using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaPowtórzonegoElementu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Element, Liczba};

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Lista złożona z powtórzonego elementu";
        public override string Opis => "Tworzy listę zawierającą wybrany element powtórzony określoną liczbę razy.";
        public override Type ZwracanyTyp => typeof(List<object>);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Element { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Liczba { get; }

        public ListaPowtórzonegoElementu()
        {
            Element = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
            Liczba = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return new List<object>(Enumerable.Repeat(Element.Zwróć<object>(), (int)Math.Round(Liczba.Zwróć<double>())));
        }
    }
}