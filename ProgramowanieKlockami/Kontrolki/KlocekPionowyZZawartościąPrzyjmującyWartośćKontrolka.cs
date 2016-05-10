using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyZZawartościąPrzyjmującyWartośćKontrolka : KlocekKontrolka<KlocekPionowyZZawartościąPrzyjmującyWartość>
    {
        public override KlocekPionowyZZawartościąPrzyjmującyWartość Kontekst => (KlocekPionowyZZawartościąPrzyjmującyWartość) DataContext;
    }
}