using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        public ObservableCollection<KlocekPionowy> Zawartość { get; }
        public Komenda OdwrócenieWidoczności { get; }

        private bool _widoczny;

        public bool Rozwinięty
        {
            get { return _widoczny; }

            set
            {
                _widoczny = value;

                OnPropertyChanged();
            }
        }

        protected KlocekPionowyZZawartością()
        {
            Zawartość = new ObservableCollection<KlocekPionowy>();
            Rozwinięty = true;
            OdwrócenieWidoczności = new Komenda(OdwróćWidoczność);
        }

        private void OdwróćWidoczność()
        {
            Rozwinięty = !Rozwinięty;
        }
    }
}