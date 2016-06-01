using GongSolutions.Wpf.DragDrop;
using System;
using System.Windows;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyPrzeciąganieZPrzybornika : IDragSource
    {
        public bool CanStartDrag(IDragInfo dragInfo)
        {
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
            dragInfo.Effects = DragDropEffects.Copy;
            Klocek klocek = (Klocek) ((Klocek) dragInfo.SourceItem).Clone();
            klocek.ZPrzybornika = true;
            dragInfo.Data = klocek;
        }
    }
}