using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyZZawartościąPrzyjmującyWartośćKontrolka : ContentControl
    {
        public IKlocekPionowyZZawartościąPrzyjmującyWartość Kontekst => (IKlocekPionowyZZawartościąPrzyjmującyWartość) DataContext;
    }
}