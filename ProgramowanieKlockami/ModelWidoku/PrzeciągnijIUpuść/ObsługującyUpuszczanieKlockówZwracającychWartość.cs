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
            WartośćKlockaPrzyjmującegoWartość wartośćKlockaPrzyjmującegoWartość = (WartośćKlockaPrzyjmującegoWartość) dropInfo.TargetCollection;
            DragDropEffects efektUpuszczenia;

            if ((upuszczanyKlocek == null) || (wartośćKlockaPrzyjmującegoWartość.PrzyjmowanyTyp != upuszczanyKlocek.ZwracanyTyp))
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            WartośćKlockaPrzyjmującegoWartość docelowaKolekcja = (WartośćKlockaPrzyjmującegoWartość) dropInfo.TargetCollection;
            KlocekZwracającyWartość upuszczanyKlocek = (KlocekZwracającyWartość) dropInfo.Data;
            upuszczanyKlocek.MiejsceUmieszczenia = docelowaKolekcja;
            upuszczanyKlocek.ZPrzybornika = false;
            docelowaKolekcja[0] = upuszczanyKlocek;
        }
    }
}