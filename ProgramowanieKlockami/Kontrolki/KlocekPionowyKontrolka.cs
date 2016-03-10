using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyKontrolka : ContentControl
    {
        public KlocekPionowy Kontekst => (KlocekPionowy) DataContext;
    }
}