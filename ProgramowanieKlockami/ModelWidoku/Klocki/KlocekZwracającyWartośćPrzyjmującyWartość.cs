using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartośćPrzyjmującyWartość : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Wartość};

        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        protected KlocekZwracającyWartośćPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(przyjmowanyTyp);
        }

        public override object Clone()
        {
            KlocekZwracającyWartośćPrzyjmującyWartość kopia = (KlocekZwracającyWartośćPrzyjmującyWartość) base.Clone();

            return kopia;
        }
    }
}