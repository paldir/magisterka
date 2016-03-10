using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekZwracającyWartośćKontrolka : ContentControl
    {
        public KlocekZwracającyWartość Kontekst => (KlocekZwracającyWartość) DataContext;
    }
}