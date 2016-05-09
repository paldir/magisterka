using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekZwracającyWartośćKontrolka : ContentControl
    {
        public KlocekZwracającyWartość Kontekst => (KlocekZwracającyWartość) DataContext;
    }
}