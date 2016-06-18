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

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr> kopia = (KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<TZwracanaWartość, TParametr>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }

        public override object Zwróć()
        {
            TZwracanaWartość domyślnaWartość = default(TZwracanaWartość);
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if (klocekZwracającyWartość == null)
                return domyślnaWartość;

            object wartość = klocekZwracającyWartość.Zwróć();

            if (!(wartość is TParametr))
                return domyślnaWartość;

            return WybranaOpcja.Zwróć((TParametr) wartość);
        }
    }
}