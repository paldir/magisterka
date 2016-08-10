namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class PrzerwijPętlę : SkokWPętli
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Przerwanie pętli";
        public override string Opis => "Przerywa wykonywanie pętli.";

        public PrzerwijPętlę() : base(PowódSkoku.PrzerwaniePętli)
        {
        }
    }
}