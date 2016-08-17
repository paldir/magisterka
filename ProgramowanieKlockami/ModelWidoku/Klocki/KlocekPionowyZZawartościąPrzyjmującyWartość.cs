using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartościąPrzyjmującyWartość : KlocekPionowyZZawartością
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Wartość};

        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        protected KlocekPionowyZZawartościąPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(przyjmowanyTyp);
        }

        public override object Clone()
        {
            KlocekPionowyZZawartościąPrzyjmującyWartość kopia = (KlocekPionowyZZawartościąPrzyjmującyWartość) base.Clone();

            return kopia;
        }
    }
}