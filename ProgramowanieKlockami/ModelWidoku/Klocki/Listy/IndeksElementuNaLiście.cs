using System.Collections.Generic;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class IndeksElementuNaLiście : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<double, List<object>, object>
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Indeks wystąpienia elementu na liście";
        public override string Opis => "Zwraca indeks pierwszego lub ostatniego elementu listy identycznego z podaną wartością.";
    }
}