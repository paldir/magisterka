using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku
{
    public abstract class Klocek
    {
        public abstract string Nazwa { get; }
        public abstract string Opis { get; }
        public abstract Brush KolorObramowania { get; }
        public KlocekPionowy Poprzedni { get; protected set; }
    }
}