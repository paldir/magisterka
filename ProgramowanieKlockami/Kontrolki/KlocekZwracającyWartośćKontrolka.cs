using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekZwracającyWartośćKontrolka : KlocekKontrolka<KlocekZwracającyWartość>
    {
        public override KlocekZwracającyWartość Kontekst => (KlocekZwracającyWartość) DataContext;
    }
}