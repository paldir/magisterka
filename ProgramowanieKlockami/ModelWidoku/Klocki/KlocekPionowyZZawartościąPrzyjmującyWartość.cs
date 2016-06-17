using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartościąPrzyjmującyWartość : KlocekPionowyZZawartością
    {
        public WartośćKlockaPrzyjmującegoWartość Wartość { get; }

        protected KlocekPionowyZZawartościąPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćKlockaPrzyjmującegoWartość(przyjmowanyTyp);
        }
    }
}