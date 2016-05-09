using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartościąPrzyjmującyWartość : KlocekPionowyZZawartością
    {
        public abstract override string Nazwa { get; }
        public abstract override string Opis { get; }
        public abstract override Brush Kolor { get; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość { get; }

        protected KlocekPionowyZZawartościąPrzyjmującyWartość()
        {
            Wartość = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}