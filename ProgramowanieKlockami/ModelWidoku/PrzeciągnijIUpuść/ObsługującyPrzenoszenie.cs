using System.Collections;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public abstract class ObsługującyPrzenoszenie : IDragSource
    {
        protected IList KolekcjaŹródłowa;
        protected int IndeksŹródłowy;
        protected object PrzenoszonyObiekt;

        public abstract void DragCancelled();
        public abstract void StartDrag(IDragInfo dragInfo);

        public bool CanStartDrag(IDragInfo dragInfo)
        {
            return true;
        }

        public void Dropped(IDropInfo dropInfo)
        {

        }
    }
}