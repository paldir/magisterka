using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class TekstOWielkościLiter : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<object, object>
    {
        public override string Nazwa => "Tekst o wielkości liter";
        public override string Opis => "Zwraca kopię tekstu z określoną wielkością liter.";

        public TekstOWielkościLiter()
        {
            Kolor = Kolory.Tekst;
        }
    }
}