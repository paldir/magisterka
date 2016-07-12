using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class StałaLogiczna : KlocekZwracającyWartośćNaPodstawieOpcji<bool>
    {
        public override string Nazwa => "StałaLogiczna";
        public override string Opis => "Zwraca fałsz.";

        public StałaLogiczna()
        {
            Kolor = Kolory.Logika;
        }
    }
}