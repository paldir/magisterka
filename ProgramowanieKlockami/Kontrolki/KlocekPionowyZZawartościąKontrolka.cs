using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyZZawartościąKontrolka : KlocekKontrolka<KlocekPionowyZZawartością>
    {
        public override KlocekPionowyZZawartością Kontekst => (KlocekPionowyZZawartością) DataContext;
    }
}