using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ElementListyOIndeksie : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista, Indeks};

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Element listy o indeksie";
        public override string Opis => "Zwraca element listy o podanym indeksie.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }

        public ElementListyOIndeksie()
        {
            Lista = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(List<object>));
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            int indeks = (int) Math.Round(Indeks.Zwróć<double>());
            List<object> lista = Lista.Zwróć<List<object>>();

            return (indeks >= 0) && (indeks < lista.Count) ? lista[indeks] : null;
        }
    }
}