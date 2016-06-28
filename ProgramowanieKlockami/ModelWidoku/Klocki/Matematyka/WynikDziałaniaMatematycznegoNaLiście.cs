using System.Collections.Generic;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WynikDziałaniaMatematycznegoNaLiście : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<double, List<object>>
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Działanie matematyczne na liście";
        public override string Opis => "Zwraca wynik działania matematycznego wykonanego na wszystkich elementach listy";
    }
}