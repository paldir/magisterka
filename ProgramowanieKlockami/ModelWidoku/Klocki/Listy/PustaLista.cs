using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustaLista : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Pusta lista";
        public override string Opis => "Tworzy pustą listę.";
        public override Type ZwracanyTyp => typeof(List<object>);

        public override object Zwróć()
        {
            return new List<object>();
        }
    }
}