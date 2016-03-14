using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Inne
{
    public class RozpoczęcieProgramu : KlocekPionowy
    {
        public override string Nazwa
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string Opis
        {
            get { throw new System.NotImplementedException(); }
        }

        public override Brush KolorObramowania => Kolory.InneObramowanie;
        public override Brush KolorWypełnienia => Kolory.InneWypełnienie;
    }
}