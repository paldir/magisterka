using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartośćPrzyjmującyWartość : KlocekZwracającyWartość
    {
        protected override WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące => new[] {Wartość};

        public WartośćKlockaPrzyjmującegoWartość Wartość { get; }

        protected KlocekZwracającyWartośćPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćKlockaPrzyjmującegoWartość(przyjmowanyTyp);
        }
    }
}