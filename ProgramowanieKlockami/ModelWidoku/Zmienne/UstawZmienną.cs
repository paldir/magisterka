using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa
        {
            get { return "Ustaw zmienną"; }
        }

        public override string Opis
        {
            get { return "Ustawia zmiennej wybraną wartość"; }
        }
    }
}