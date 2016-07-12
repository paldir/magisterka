using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private bool _aktualnieWykonywany;
        private bool _punktPrzerwania;

        public bool Debugowanie { get; set; }
        public KlocekPionowyZZawartością Rodzic { get; set; }

        public bool AktualnieWykonywany
        {
            get { return _aktualnieWykonywany; }

            set
            {
                _aktualnieWykonywany = value;
                Kolor = KolorObramowania = AktualnieWykonywany ? Kolory.AktualnieWykonywany : KolorPierwotny;
            }
        }

        public bool PunktPrzerwania
        {
            get { return _punktPrzerwania; }

            set
            {
                _punktPrzerwania = value;

                OnPropertyChanged();
            }
        }

        public abstract void Wykonaj();
    }
}