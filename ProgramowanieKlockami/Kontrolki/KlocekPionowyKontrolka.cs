using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyKontrolka : ContentControl
    {
        public IKlocekPionowy Kontekst => (IKlocekPionowy) DataContext;
    }
}