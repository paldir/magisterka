using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public abstract Type ZwracanyTyp { get; }

        public WartośćKlockaPrzyjmującegoWartość MiejsceUmieszczenia { get; set; }

        public abstract object Zwróć();

        protected T Zwróć<T>(Func<T> funkcja, params WartośćKlockaPrzyjmującegoWartość[] klocki)
        {
            foreach (WartośćKlockaPrzyjmującegoWartość wartośćKlocka in klocki)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlocka[0];

                if ((klocekZwracającyWartość == null) || (wartośćKlocka.PrzyjmowanyTyp != klocekZwracającyWartość.Zwróć().GetType()))
                    return default(T);
            }

            return funkcja();
        }
    }
}