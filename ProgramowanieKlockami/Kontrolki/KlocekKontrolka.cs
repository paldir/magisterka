using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public abstract class KlocekKontrolka<T> : ContentControl where T : Klocek
    {
        public abstract T Kontekst { get; }
    }
}