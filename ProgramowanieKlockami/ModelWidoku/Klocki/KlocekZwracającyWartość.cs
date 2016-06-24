using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        protected abstract WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące { get; }

        public abstract Type ZwracanyTyp { get; }

        public WartośćKlockaPrzyjmującegoWartość MiejsceUmieszczenia { get; set; }

        public T Zwróć<T>()
        {
            return (T) Convert.ChangeType(Zwróć(), typeof(T));
        }

        protected abstract object ZwróćNiebezpiecznie();

        public virtual object Zwróć()
        {
            foreach (WartośćKlockaPrzyjmującegoWartość wartośćKlocka in KlockiKonfigurujące)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlocka[0];

                if ((klocekZwracającyWartość == null) || (wartośćKlocka.PrzyjmowanyTyp != klocekZwracającyWartość.Zwróć().GetType()))
                    return Activator.CreateInstance(ZwracanyTyp);
            }

            return ZwróćNiebezpiecznie();
        }
    }
}