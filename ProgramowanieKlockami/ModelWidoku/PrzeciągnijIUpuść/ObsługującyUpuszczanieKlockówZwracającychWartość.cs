using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówZwracającychWartość : ObsługującyUpuszczanie<KlocekZwracającyWartość>
    {
        public override void Drop(IDropInfo dropInfo)
        {
            ObservableCollection<KlocekZwracającyWartość> docelowaKolekcja = (ObservableCollection<KlocekZwracającyWartość>) dropInfo.TargetCollection;
            KlocekZwracającyWartość upuszczanyKlocek = (KlocekZwracającyWartość) dropInfo.Data;
            upuszczanyKlocek.MiejsceUmieszczenia = docelowaKolekcja;
            upuszczanyKlocek.ZPrzybornika = false;
            docelowaKolekcja[0] = upuszczanyKlocek;
        }
    }
}