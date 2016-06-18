using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr> : KlocekZwracającyWartość
    {
        public override Type ZwracanyTyp => typeof(TZwracanaWartość);

        public WartośćKlockaPrzyjmującegoWartość Wartość1 { get; }
        public WartośćKlockaPrzyjmującegoWartość Wartość2 { get; }

        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<TZwracanaWartość, TParametr> WybranaOpcja { get; set; }

        protected KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów()
        {
            Wartość1 = new WartośćKlockaPrzyjmującegoWartość(typeof(TParametr));
            Wartość2 = new WartośćKlockaPrzyjmującegoWartość(typeof(TParametr));
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }

        public override object Zwróć()
        {
            TZwracanaWartość domyślnaWartość = default(TZwracanaWartość);
            KlocekZwracającyWartość klocekZwracającyWartość1 = Wartość1[0];
            KlocekZwracającyWartość klocekZwracającyWartość2 = Wartość2[0];

            if ((klocekZwracającyWartość1 == null) || (klocekZwracającyWartość2 == null))
                return domyślnaWartość;

            object wartość1 = klocekZwracającyWartość1.Zwróć();
            object wartość2 = klocekZwracającyWartość2.Zwróć();

            if (!(wartość1 is TParametr) || !(wartość2 is TParametr))
                return domyślnaWartość;

            return WybranaOpcja.Zwróć((TParametr) wartość1, (TParametr) wartość2);
        }
    }
}