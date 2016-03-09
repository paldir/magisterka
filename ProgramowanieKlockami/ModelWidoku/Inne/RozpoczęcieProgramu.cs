using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Inne
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

        public override Brush KolorObramowania => Brushes.Black;
    }
}