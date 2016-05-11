using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        public ObservableCollection<KlocekZwracającyWartość> Wartość { get; }

        protected KlocekPionowyPrzyjmującyWartość()
        {
            Wartość = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}