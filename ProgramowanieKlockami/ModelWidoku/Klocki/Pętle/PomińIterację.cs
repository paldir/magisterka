namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class PomińIterację : SkokWPętli
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Pominięcie iteracji";
        public override string Opis => "Pomija bieżącą iterację pętli.";

        public PomińIterację() : base(PowódSkoku.PominięcieIteracji)
        {
        }
    }
}