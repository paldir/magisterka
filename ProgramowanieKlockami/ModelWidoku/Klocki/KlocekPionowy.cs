using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        public ObservableCollection<KlocekPionowy> MiejsceUmieszczenia { get; set; }

        public abstract void Wykonaj();
    }
}