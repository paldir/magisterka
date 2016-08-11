namespace ProgramowanieKlockami.ModelWidoku.Klocki.Inne
{
    public sealed class RozpoczęcieProgramu : KlocekPionowyZZawartością
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => null;

        public override string Opis => null;

        public RozpoczęcieProgramu()
        {
            Kolor = Kolory.Funkcje;
        }
    }
}