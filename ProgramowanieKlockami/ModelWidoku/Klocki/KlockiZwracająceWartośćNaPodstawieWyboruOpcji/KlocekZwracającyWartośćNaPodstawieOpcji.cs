using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcji<T> : KlocekZwracającyWartość
    {
        protected override WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące => new WartośćKlockaPrzyjmującegoWartość[0];

        public override Type ZwracanyTyp => typeof(T);

        public IOpcjaZwracającaWartość<T> WybranaOpcja { get; set; }

        protected override object ZwróćNiebezpiecznie()
        {
            return WybranaOpcja.Wartość;
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcji<T> kopia = (KlocekZwracającyWartośćNaPodstawieOpcji<T>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}