using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartośćPrzyjmującyWartość : KlocekZwracającyWartość
    {
        public ObservableCollection<KlocekZwracającyWartość> Wartość { get; }

        protected KlocekZwracającyWartośćPrzyjmującyWartość()
        {
            Wartość = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}