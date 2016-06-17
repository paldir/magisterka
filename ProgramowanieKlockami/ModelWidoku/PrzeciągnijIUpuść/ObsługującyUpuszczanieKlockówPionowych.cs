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
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ZawartośćKlockaPionowegoZZawartością docelowaKolekcja = (ZawartośćKlockaPionowegoZZawartością) dropInfo.TargetCollection;
            KlocekPionowy upuszczanyKlocek = (KlocekPionowy) dropInfo.Data;
            upuszczanyKlocek.Rodzic = docelowaKolekcja.KlocekPionowyZZawartością;
            upuszczanyKlocek.ZPrzybornika = false;

            docelowaKolekcja.Insert(dropInfo.InsertIndex, upuszczanyKlocek);
        }
    }
}