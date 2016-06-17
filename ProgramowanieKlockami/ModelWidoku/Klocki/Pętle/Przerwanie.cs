namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class Przerwanie : SkokWPętli
    {
        public override string Nazwa => "Przerwanie pętli";
        public override string Opis => "Przerywa wykonywanie pętli.";

        public Przerwanie() : base(PowódSkoku.PrzerwaniePętli)
        {
        }
    }
}