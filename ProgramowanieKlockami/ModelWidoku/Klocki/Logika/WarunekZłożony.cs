using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class WarunekZłożony : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<bool, bool>
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Warunek złożony";
        public override string Opis => "Zwraca prawdę, jeśli oba warunki są prawdziwe lub gdy przynajmniej jeden jest prawdziwy.";
    }
}