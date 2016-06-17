using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        public WartośćKlockaPrzyjmującegoWartość Wartość { get; }

        protected KlocekPionowyPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćKlockaPrzyjmującegoWartość(przyjmowanyTyp);
        }
    }
}