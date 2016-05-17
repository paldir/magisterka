using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public abstract class ObsługującyUpuszczanie<T> : IDropTarget where T : Klocek
    {
        public void DragOver(IDropInfo dropInfo)
        {
            T upuszczanyKlocek = dropInfo.Data as T;
            DragDropEffects efektUpuszczenia;

            if (upuszczanyKlocek == null)
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = typeof(T).IsAssignableFrom(typeof(KlocekPionowy)) ? DropTargetAdorners.Insert : DropTargetAdorners.Highlight;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public abstract void Drop(IDropInfo dropInfo);
    }
}