using System;
using System.Collections.ObjectModel;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówPionowych : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            KlocekPionowy upuszczanyKlocek = dropInfo.Data as KlocekPionowy;
            DragDropEffects efektUpuszczenia;

            if (upuszczanyKlocek == null)
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = DragDropEffects.Copy;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ObservableCollection<KlocekPionowy> docelowaKolekcja = (ObservableCollection<KlocekPionowy>) dropInfo.TargetCollection;
            KlocekPionowy kopiaUpuszczanegoObiektu = (KlocekPionowy) Activator.CreateInstance(dropInfo.Data.GetType());
            kopiaUpuszczanegoObiektu.MiejsceUmieszczenia = docelowaKolekcja;

            docelowaKolekcja.Insert(dropInfo.InsertIndex, kopiaUpuszczanegoObiektu);
        }
    }
}