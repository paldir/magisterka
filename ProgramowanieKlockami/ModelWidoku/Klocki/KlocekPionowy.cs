using System;
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
            Type typObiektu = dropInfo.Data.GetType();
            Type typListy = dropInfo.TargetCollection.GetType().GetElementType();
            DragDropEffects efektUpuszczenia = typListy.IsAssignableFrom(typObiektu) ? DragDropEffects.Copy : DragDropEffects.None;
            dropInfo.Effects = efektUpuszczenia;
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
        }

        public virtual void Drop(IDropInfo dropInfo)
        {
            KlocekPionowy klocek = dropInfo.Data as KlocekPionowy;

            if (klocek != null)
                Następny = klocek;
        }
    }
}