using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private bool _aktualnieWykonywany;
        private Brush _kolorPierwotny;
        private bool _punktPrzerwania;

        public bool Debugowanie { get; set; }
        public KlocekPionowyZZawartością Rodzic { get; set; }

        public bool AktualnieWykonywany
        {
            get { return _aktualnieWykonywany; }

            set
            {
                _aktualnieWykonywany = value;

                if (AktualnieWykonywany)
                {
                    _kolorPierwotny = Kolor;

                }
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