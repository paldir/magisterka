using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class IndeksElementuNaLiście : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<double, ZmiennaTypuListowego, object>
    {
        public override string Nazwa => "Indeks wystąpienia elementu na liście";
        public override string Opis => "Zwraca indeks pierwszego lub ostatniego elementu listy identycznego z podaną wartością.";

        public IndeksElementuNaLiście()
        {
            Kolor = Kolory.Listy;
        }
    }
}