using System.Windows;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek, IDropTarget
    {
        private KlocekPionowy _następny;

        public KlocekPionowy Następny
        {
            get { return _następny; }

            set
            {
                _następny = value;

                OnPropertyChanged();
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Copy;
        }

        public virtual void Drop(IDropInfo dropInfo)
        {
            KlocekPionowy klocek = dropInfo.Data as KlocekPionowy;

            if (klocek != null)
                Następny = klocek;
        }
    }
}