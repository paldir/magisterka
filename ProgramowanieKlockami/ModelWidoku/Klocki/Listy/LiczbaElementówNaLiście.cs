using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class LiczbaElementówNaLiście : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override string Nazwa => "Liczba elementów na liście";
        public override string Opis => "Zwraca liczbę elementów na liście";
        public override Type ZwracanyTyp => typeof(double);

        public LiczbaElementówNaLiście() : base(typeof(ZmiennaTypuListowego))
        {
            Kolor = Kolory.Listy;
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return Wartość.Zwróć<ZmiennaTypuListowego>().Count;
        }
    }
}