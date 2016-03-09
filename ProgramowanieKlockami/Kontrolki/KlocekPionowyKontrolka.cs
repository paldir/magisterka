using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyKontrolka : UserControl
    {
        public KlocekPionowy Kontekst
        {
            get { return DataContext as KlocekPionowy; }
            set { DataContext = value; }
        }
    }
}