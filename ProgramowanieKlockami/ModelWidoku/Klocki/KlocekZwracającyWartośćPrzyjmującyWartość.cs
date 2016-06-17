using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartośćPrzyjmującyWartość : KlocekZwracającyWartość
    {
        public WartośćKlockaPrzyjmującegoWartość Wartość { get; }

        protected KlocekZwracającyWartośćPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćKlockaPrzyjmującegoWartość(przyjmowanyTyp);
        }
    }
}