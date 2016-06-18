using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class StałaLogiczna : KlocekZwracającyWartośćNaPodstawieOpcji<bool>
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "StałaLogiczna";
        public override string Opis => "Zwraca fałsz.";
    }
}