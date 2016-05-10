using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyKontrolka : KlocekKontrolka<KlocekPionowy>
    {
        public override KlocekPionowy Kontekst => (KlocekPionowy) DataContext;
    }
}