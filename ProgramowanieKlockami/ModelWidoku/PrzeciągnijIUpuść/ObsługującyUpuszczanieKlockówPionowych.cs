using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówPionowych : ObsługującyUpuszczanie<KlocekPionowy>
    {
        public override void Drop(IDropInfo dropInfo)
        {
            ObservableCollection<KlocekPionowy> docelowaKolekcja = (ObservableCollection<KlocekPionowy>) dropInfo.TargetCollection;
            KlocekPionowy upuszczanyKlocek = (KlocekPionowy) dropInfo.Data;
            upuszczanyKlocek.MiejsceUmieszczenia = docelowaKolekcja;
            upuszczanyKlocek.ZPrzybornika = false;

            docelowaKolekcja.Insert(dropInfo.InsertIndex, upuszczanyKlocek);
        }
    }
}