using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartościąPrzyjmującyWartość : KlocekPionowyZZawartością
    {
        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        protected KlocekPionowyZZawartościąPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(przyjmowanyTyp);
        }

        public override object Clone()
        {
            KlocekPionowyZZawartościąPrzyjmującyWartość kopia = (KlocekPionowyZZawartościąPrzyjmującyWartość) base.Clone();
            kopia.Wartość[0] = (KlocekZwracającyWartość) Wartość[0]?.Clone();

            return kopia;
        }
    }
}