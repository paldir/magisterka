using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public interface IKlocek
    {
        string Nazwa { get; }
        string Opis { get; }
        Brush Kolor { get; }
    }
}