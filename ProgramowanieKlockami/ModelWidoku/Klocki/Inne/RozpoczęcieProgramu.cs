namespace ProgramowanieKlockami.ModelWidoku.Klocki.Inne
{
    public sealed class RozpoczęcieProgramu : KlocekPionowyZZawartością
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string Opis
        {
            get { throw new System.NotImplementedException(); }
        }

        public RozpoczęcieProgramu()
        {
            Kolor = Kolory.Funkcje;
        }
    }
}