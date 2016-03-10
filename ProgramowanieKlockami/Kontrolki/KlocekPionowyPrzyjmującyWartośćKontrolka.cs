using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyPrzyjmującyWartośćKontrolka : ContentControl
    {
        public KlocekPionowyPrzyjmującyWartość Kontekst => (KlocekPionowyPrzyjmującyWartość) DataContext;
    }
}