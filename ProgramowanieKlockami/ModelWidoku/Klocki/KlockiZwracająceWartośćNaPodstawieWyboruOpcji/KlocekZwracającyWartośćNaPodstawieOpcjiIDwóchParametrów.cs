using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr1, TParametr2> : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Wartość1, Wartość2};

        public override Type ZwracanyTyp => typeof(TZwracanaWartość);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość1 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość2 { get; }

        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<TZwracanaWartość, TParametr1, TParametr2> WybranaOpcja { get; set; }

        protected KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów()
        {
            Wartość1 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(TParametr1));
            Wartość2 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(TParametr2));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaOpcja.Zwróć(Wartość1.Zwróć<TParametr1>(), Wartość2.Zwróć<TParametr2>());
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr1, TParametr2> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<TZwracanaWartość, TParametr1, TParametr2>) base.Clone();
            kopia.Wartość1[0] = (KlocekZwracającyWartość) Wartość1[0]?.Clone();
            kopia.Wartość2[0] = (KlocekZwracającyWartość) Wartość2[0]?.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}