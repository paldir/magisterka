using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private bool _punktPrzerwania;

        public KlocekPionowyZZawartością Rodzic { get; set; }

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