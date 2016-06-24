using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr> : KlocekZwracającyWartość
    {
        protected override WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące => new[] {Wartość1, Wartość2};

        public override Type ZwracanyTyp => typeof(TZwracanaWartość);

        public WartośćKlockaPrzyjmującegoWartość Wartość1 { get; }
        public WartośćKlockaPrzyjmującegoWartość Wartość2 { get; }

        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<TZwracanaWartość, TParametr> WybranaOpcja { get; set; }

        protected KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów()
        {
            Wartość1 = new WartośćKlockaPrzyjmującegoWartość(typeof(TParametr));
            Wartość2 = new WartośćKlockaPrzyjmującegoWartość(typeof(TParametr));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaOpcja.Zwróć(Wartość1.Zwróć<TParametr>(), Wartość2.Zwróć<TParametr>());
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}