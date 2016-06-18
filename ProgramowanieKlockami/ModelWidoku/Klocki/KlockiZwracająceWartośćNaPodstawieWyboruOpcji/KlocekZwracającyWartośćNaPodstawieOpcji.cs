using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class KlocekZwracającyWartośćNaPodstawieOpcji<T> : KlocekZwracającyWartość
    {
        public override Type ZwracanyTyp => typeof(T);

        public IOpcjaZwracającaWartość<T> WybranaOpcja { get; set; }

        public override object Clone()
        {
            KlocekZwracającyWartośćNaPodstawieOpcji<T> kopia = (KlocekZwracającyWartośćNaPodstawieOpcji<T>) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }

        public override object Zwróć()
        {
            return WybranaOpcja.Wartość;
        }
    }
}