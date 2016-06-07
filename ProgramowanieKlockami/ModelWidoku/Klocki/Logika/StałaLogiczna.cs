using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.StałeLogiczne;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class StałaLogiczna : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "StałaLogiczna";
        public override string Opis => "Zwraca fałsz.";

        public IStałaLogiczna WybranaStałaLogiczna { get; set; }

        public override object Zwróć()
        {
            return WybranaStałaLogiczna.WartośćLogiczna;
        }

        public override object Clone()
        {
            StałaLogiczna kopia = (StałaLogiczna) base.Clone();
            kopia.WybranaStałaLogiczna = WybranaStałaLogiczna;

            return kopia;
        }
    }
}