using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Wartość};

        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        protected KlocekPionowyPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(przyjmowanyTyp);
        }

        public override object Clone()
        {
            KlocekPionowyPrzyjmującyWartość kopia = (KlocekPionowyPrzyjmującyWartość) base.Clone();

            return kopia;
        }
    }
}