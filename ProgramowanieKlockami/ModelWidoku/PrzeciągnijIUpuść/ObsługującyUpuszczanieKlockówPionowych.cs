using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówPionowych : ObsługującyUpuszczanie<KlocekPionowy>
    {
        public override void Drop(IDropInfo dropInfo)
        {
            ZawartośćKlockaPionowegoZZawartością docelowaKolekcja = (ZawartośćKlockaPionowegoZZawartością) dropInfo.TargetCollection;
            KlocekPionowy upuszczanyKlocek = (KlocekPionowy) dropInfo.Data;
            upuszczanyKlocek.Rodzic = docelowaKolekcja.KlocekPionowyZZawartością;
            upuszczanyKlocek.ZPrzybornika = false;

            docelowaKolekcja.Insert(dropInfo.InsertIndex, upuszczanyKlocek);
        }
    }
}