using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ElementListyOIndeksie : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista, Indeks};

        public override string Nazwa => "Element listy o indeksie";
        public override string Opis => "Zwraca element listy o podanym indeksie.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }

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

        public override object Clone()
        {
            ElementListyOIndeksie kopia = (ElementListyOIndeksie) base.Clone();
            kopia.Indeks[0] = (KlocekZwracającyWartość) Indeks[0]?.Clone();
            kopia.Lista[0] = (KlocekZwracającyWartość) Lista[0]?.Clone();

            return kopia;
        }
    }
}