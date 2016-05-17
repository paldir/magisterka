using System.Collections;
using System.Windows;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyPrzenoszenieKlockówPionowych : ObsługującyPrzenoszenie
    {
        public override void DragCancelled()
        {
            KolekcjaŹródłowa.Insert(IndeksŹródłowy, PrzenoszonyObiekt);
        }

        public override void StartDrag(IDragInfo dragInfo)
        {
            dragInfo.Effects = DragDropEffects.Move;
            dragInfo.Data = PrzenoszonyObiekt = dragInfo.SourceItem;
            KolekcjaŹródłowa = (IList) dragInfo.SourceCollection;
            IndeksŹródłowy = dragInfo.SourceIndex;

            KolekcjaŹródłowa.RemoveAt(IndeksŹródłowy);
        }
    }
}