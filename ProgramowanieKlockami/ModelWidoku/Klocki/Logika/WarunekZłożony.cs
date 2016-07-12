using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class WarunekZłożony : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<bool, bool, bool>
    {
        public override string Nazwa => "Warunek złożony";
        public override string Opis => "Zwraca prawdę, jeśli oba warunki są prawdziwe lub gdy przynajmniej jeden jest prawdziwy.";

        public WarunekZłożony()
        {
            Kolor = Kolory.Logika;
        }
    }
}