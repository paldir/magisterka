﻿using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        protected abstract WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące { get; }

        public abstract Type ZwracanyTyp { get; }

        public WartośćWewnętrznegoKlockaZwracającegoWartość MiejsceUmieszczenia { get; set; }

        private object Zwróć()
        {
            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlocka in KlockiKonfigurujące)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlocka[0];

                if (klocekZwracającyWartość != null)
                {
                    object zwróconaWartość = klocekZwracającyWartość.Zwróć();

                    if (wartośćKlocka.PrzyjmowanyTyp.IsInstanceOfType(zwróconaWartość))
                        continue;
                }

                Błąd = true;

                return ZwracanyTyp == typeof(object) ? string.Empty : Activator.CreateInstance(ZwracanyTyp);
            }

            Błąd = false;

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

            Błąd = true;

            return Activator.CreateInstance<T>();
        }
    }
}