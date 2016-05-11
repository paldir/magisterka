using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
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