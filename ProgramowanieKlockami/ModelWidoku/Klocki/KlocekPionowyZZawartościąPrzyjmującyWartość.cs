using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartościąPrzyjmującyWartość : KlocekPionowyZZawartością
    {
        public ObservableCollection<KlocekZwracającyWartość> Wartość { get; }

        protected KlocekPionowyZZawartościąPrzyjmującyWartość()
        {
            Wartość = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}