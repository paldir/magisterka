namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        public KlocekPionowyZZawartością Rodzic { get; set; }

        public abstract void Wykonaj();
    }
}