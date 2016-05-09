using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyZZawartościąPrzyjmującyWartośćKontrolka : ContentControl
    {
        public KlocekPionowyZZawartościąPrzyjmującyWartość Kontekst => (KlocekPionowyZZawartościąPrzyjmującyWartość) DataContext;
    }
}