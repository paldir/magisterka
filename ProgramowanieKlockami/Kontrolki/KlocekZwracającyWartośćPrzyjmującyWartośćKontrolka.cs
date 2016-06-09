using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekZwracającyWartośćPrzyjmującyWartośćKontrolka : KlocekKontrolka<KlocekZwracającyWartośćPrzyjmującyWartość>
    {
        public override KlocekZwracającyWartośćPrzyjmującyWartość Kontekst => (KlocekZwracającyWartośćPrzyjmującyWartość) DataContext;
    }
}