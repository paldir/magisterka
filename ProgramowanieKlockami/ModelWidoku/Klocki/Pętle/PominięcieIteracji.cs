namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class PominięcieIteracji : SkokWPętli
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Pominięcie iteracji";
        public override string Opis => "Pomija bieżącą iterację pętli.";

        public PominięcieIteracji() : base(PowódSkoku.PominięcieIteracji)
        {
        }
    }
}