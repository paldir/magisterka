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
            IKlocekPionowy upuszczanyKlocek = dropInfo.Data as IKlocekPionowy;
            dropInfo.Effects = upuszczanyKlocek == null ? DragDropEffects.None : DragDropEffects.Copy;
            dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ObservableCollection<IKlocekPionowy> docelowaKolekcja = (ObservableCollection<IKlocekPionowy>) dropInfo.TargetCollection;
            IKlocekPionowy kopiaUpuszczanegoObiektu = (IKlocekPionowy) Activator.CreateInstance(dropInfo.Data.GetType());

            docelowaKolekcja.Insert(dropInfo.InsertIndex, kopiaUpuszczanegoObiektu);
        }
    }
}