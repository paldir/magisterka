using System.Collections.ObjectModel;
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

        public ObservableCollection<KlocekPionowy> Zawartość { get; private set; }

        public override Brush Kolor => Kolory.Inne;

        public RozpoczęcieProgramu()
        {
            Zawartość = new ObservableCollection<KlocekPionowy>();
        }
    }
}