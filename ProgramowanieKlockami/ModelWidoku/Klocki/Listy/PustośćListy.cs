using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustośćListy : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista};

        public override string Nazwa => "Sprawdzenie pustości listy";
        public override string Opis => "Zwraca prawdę, jeśli lista jest pusta.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }

        public PustośćListy()
        {
            Kolor = Kolory.Listy;
            Lista = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(ZmiennaTypuListowego));
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            return Lista.Zwróć<ZmiennaTypuListowego>(sprawdzanieBłędów).Count == 0;
        }

        public override object Clone()
        {
            PustośćListy kopia = (PustośćListy) base.Clone();

            return kopia;
        }
    }
}