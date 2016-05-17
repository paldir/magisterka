using System.Collections;
using System.Windows;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyPrzenoszenieKlockówZwracającychWartość : ObsługującyPrzenoszenie
    {
        public override void DragCancelled()
        {
            KolekcjaŹródłowa[0] = PrzenoszonyObiekt;
        }

        public override void StartDrag(IDragInfo dragInfo)
        {
            dragInfo.Effects = DragDropEffects.Move;
            dragInfo.Data = PrzenoszonyObiekt = dragInfo.SourceItem;
            KolekcjaŹródłowa = (IList) dragInfo.SourceCollection;
            IndeksŹródłowy = dragInfo.SourceIndex;
            KolekcjaŹródłowa[0] = null;
        }
    }
}