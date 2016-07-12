using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ElementListyOIndeksie : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista, Indeks};

        public override string Nazwa => "Element listy o indeksie";
        public override string Opis => "Zwraca element listy o podanym indeksie.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }

        public ElementListyOIndeksie()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Listy;
            Lista = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(ZmiennaTypuListowego));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            int indeks = (int) Math.Round(Indeks.Zwróć<double>());
            ZmiennaTypuListowego lista = Lista.Zwróć<ZmiennaTypuListowego>();

            return (indeks >= 0) && (indeks < lista.Count) ? lista[indeks] : null;
        }
    }
}