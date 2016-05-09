using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        public abstract override string Nazwa { get; }
        public abstract override string Opis { get; }
        public abstract override Brush Kolor { get; }
        public ObservableCollection<KlocekPionowy> Zawartość { get; }
        public Komenda OdwrócenieWidoczności { get; }

        private bool _widoczny;

        public bool Widoczny
        {
            get { return _widoczny; }

            private set
            {
                _widoczny = value;

                OnPropertyChanged();
            }
        }

        protected KlocekPionowyZZawartością()
        {
            Zawartość = new ObservableCollection<KlocekPionowy>();
            Widoczny = true;
            OdwrócenieWidoczności = new Komenda(OdwróćWidoczność);
        }

        private void OdwróćWidoczność()
        {
            Widoczny = !Widoczny;
        }
    }
}