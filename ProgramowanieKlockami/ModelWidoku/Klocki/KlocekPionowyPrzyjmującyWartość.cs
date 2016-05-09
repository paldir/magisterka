using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        public abstract override string Nazwa { get; }
        public abstract override string Opis { get; }
        public abstract override Brush Kolor { get; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość { get; }

        protected KlocekPionowyPrzyjmującyWartość()
        {
            Wartość = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}