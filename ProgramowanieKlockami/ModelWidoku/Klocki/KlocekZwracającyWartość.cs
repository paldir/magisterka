using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public ObservableCollection<KlocekZwracającyWartość> MiejsceUmieszczenia { get; set; }

        public abstract object Zwróć();
    }
}