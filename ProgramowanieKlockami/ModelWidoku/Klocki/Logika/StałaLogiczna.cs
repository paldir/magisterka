using System;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class StałaLogiczna : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "StałaLogiczna";
        public override string Opis => "Zwraca fałsz.";
        public override Type ZwracanyTyp => typeof(bool);

        public IOpcjaZwracającaWartość<bool> WybranaStałaLogiczna { get; set; }

        public override object Zwróć()
        {
            return WybranaStałaLogiczna.Wartość;
        }

        public override object Clone()
        {
            StałaLogiczna kopia = (StałaLogiczna) base.Clone();
            kopia.WybranaStałaLogiczna = WybranaStałaLogiczna;

            return kopia;
        }
    }
}