using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyZZawartością : ContentControl
    {
        public IKlocekPionowyZZawartością Kontekst => (IKlocekPionowyZZawartością) DataContext;
    }
}