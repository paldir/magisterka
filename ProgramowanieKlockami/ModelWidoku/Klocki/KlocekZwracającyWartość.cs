using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        protected abstract WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące { get; }

        public abstract Type ZwracanyTyp { get; }

        public WartośćKlockaPrzyjmującegoWartość MiejsceUmieszczenia { get; set; }

        private object Zwróć()
        {
            foreach (WartośćKlockaPrzyjmującegoWartość wartośćKlocka in KlockiKonfigurujące)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlocka[0];

                if (klocekZwracającyWartość != null)
                {
                    object zwróconaWartość = klocekZwracającyWartość.Zwróć();

                    if (wartośćKlocka.PrzyjmowanyTyp.IsInstanceOfType(zwróconaWartość))
                        continue;
                }

                return Activator.CreateInstance(ZwracanyTyp);
            }

            return ZwróćNiebezpiecznie();
        }

        protected abstract object ZwróćNiebezpiecznie();

        public T Zwróć<T>()
        {
            object zwróconaWartość = Zwróć();
            Type typDocelowy = typeof(T);

            if (zwróconaWartość != null)
            {
                if (typDocelowy.IsInstanceOfType(zwróconaWartość))
                    return (T) zwróconaWartość;

                try
                {
                    return (T) Convert.ChangeType(zwróconaWartość, typDocelowy);
                }
                catch (InvalidCastException)
                {
                }
            }

            return Activator.CreateInstance<T>();
        }
    }
}