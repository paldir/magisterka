using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr> : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Type ZwracanyTyp => typeof(TZwracanaWartość);

        public OpcjaZwracającaWartośćNaPodstawieParametru<TZwracanaWartość, TParametr> WybranaOpcja { get; set; }

        protected KlocekZwracającyWartośćNaPodstawieOpcjiIParametru() : base(typeof(TParametr))
        {
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            return WybranaOpcja.Zwróć(Wartość.Zwróć<TParametr>(sprawdzanieBłędów));
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}