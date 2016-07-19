using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr> : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Type ZwracanyTyp => typeof(TZwracanaWartość);

        public IOpcjaZwracającaWartośćNaPodstawieParametru<TZwracanaWartość, TParametr> WybranaOpcja { get; set; }

        protected KlocekZwracającyWartośćNaPodstawieOpcjiIParametru() : base(typeof(TParametr))
        {
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaOpcja.Zwróć(Wartość.Zwróć<TParametr>());
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr>) base.Clone();
            kopia.Wartość[0] = (KlocekZwracającyWartość) Wartość[0]?.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}