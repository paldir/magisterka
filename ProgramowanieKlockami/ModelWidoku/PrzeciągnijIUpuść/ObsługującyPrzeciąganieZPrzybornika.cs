using GongSolutions.Wpf.DragDrop;
using System;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyPrzeciąganieZPrzybornika : IDragSource
    {
        public bool CanStartDrag(IDragInfo dragInfo)
        {
            dragInfo.Effects = System.Windows.DragDropEffects.Copy;

            return true;
        }

        public void DragCancelled()
        {

        }

        public void Dropped(IDropInfo dropInfo)
        {

        }

        public void StartDrag(IDragInfo dragInfo)
        {
            dragInfo.Effects = System.Windows.DragDropEffects.Copy;
            dragInfo.Data = Activator.CreateInstance(dragInfo.SourceItem.GetType());
        }
    }
}