using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class LiczbaElementówNaLiście : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Liczba elementów na liście";
        public override string Opis => "Zwraca liczbę elementów na liście";
        public override Type ZwracanyTyp => typeof(double);

        public LiczbaElementówNaLiście() : base(typeof(List<object>))
        {
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            object lista = klocekZwracającyWartość?.Zwróć();

            if (!(lista is List<object>))
                return 0;

            return ((List<object>) lista).Count;
        }
    }
}