using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        private KlocekZwracającyWartość _wartość;

        public KlocekZwracającyWartość Wartość
        {
            get { return _wartość; }

            set
            {
                _wartość = value;

                OnPropertyChanged();
            }
        }

        public override void Drop(IDropInfo dropInfo)
        {
            base.Drop(dropInfo);

            KlocekZwracającyWartość klocek = dropInfo.Data as KlocekZwracającyWartość;

            if (klocek != null)
                Wartość = klocek;
        }
    }
}