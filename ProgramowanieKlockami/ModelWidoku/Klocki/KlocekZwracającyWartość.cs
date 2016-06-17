using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public abstract Type ZwracanyTyp { get; }

        public WartośćKlockaPrzyjmującegoWartość MiejsceUmieszczenia { get; set; }

        public abstract object Zwróć();
    }
}