using System.Collections;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public abstract class ObsługującyPrzenoszenie : IDragSource
    {
        protected IList KolekcjaŹródłowa { get; set; }
        protected int IndeksŹródłowy { get; set; }
        protected object PrzenoszonyObiekt { get; set; }

        public abstract void DragCancelled();
        public abstract void StartDrag(IDragInfo dragInfo);

        public bool CanStartDrag(IDragInfo dragInfo) => true;

        public void Dropped(IDropInfo dropInfo)
        {

        }
    }
}