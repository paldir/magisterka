using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyPrzyjmującyWartośćKontrolka : KlocekKontrolka<KlocekPionowyPrzyjmującyWartość>
    {
        public override KlocekPionowyPrzyjmującyWartość Kontekst => (KlocekPionowyPrzyjmującyWartość) DataContext;
    }
}