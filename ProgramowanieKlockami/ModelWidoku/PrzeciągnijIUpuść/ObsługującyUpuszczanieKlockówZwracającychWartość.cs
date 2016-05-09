using System;
using System.Collections.ObjectModel;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówZwracającychWartość : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            KlocekZwracającyWartość upuszczanyKlocek = dropInfo.Data as KlocekZwracającyWartość;
            DragDropEffects efektUpuszczenia;

            if (upuszczanyKlocek == null)
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = DragDropEffects.Copy;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ObservableCollection<KlocekZwracającyWartość> docelowaKolekcja = (ObservableCollection<KlocekZwracającyWartość>) dropInfo.TargetCollection;
            docelowaKolekcja[0] = (KlocekZwracającyWartość) Activator.CreateInstance(dropInfo.Data.GetType());
        }
    }
}