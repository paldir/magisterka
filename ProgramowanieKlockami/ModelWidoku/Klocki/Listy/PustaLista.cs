using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustaLista : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Pusta lista";
        public override string Opis => "Tworzy pustą listę.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        public PustaLista()
        {
            Kolor = Kolory.Listy;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            return new ZmiennaTypuListowego();
        }
    }
}