using System;
using System.Threading;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class PobranyTekst : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Pobrany tekst";
        public override string Opis => "Pobiera od użytkownika tekst/liczbę.";
        public override Type ZwracanyTyp => typeof(object);

        public IPobieranieTekstu WybranaOpcja { get; set; }

        public PobranyTekst() : base(typeof(object))
        {
        }

        protected override object ZwróćNiebezpiecznie()
        {
            return null;
        }

        public override object Clone()
        {
            PobranyTekst kopia = (PobranyTekst) base.Clone();
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}