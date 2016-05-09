using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public abstract override string Nazwa { get; }
        public abstract override string Opis { get; }
        public abstract override Brush Kolor { get; }
    }
}