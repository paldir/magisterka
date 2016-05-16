using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        public Komenda OdwrócenieWidoczności { get; }
        public ObservableCollection<KlocekPionowy> Zawartość { get; }

        private bool _rozwinięty;
        public bool Rozwinięty
        {
            get { return _rozwinięty; }

            set
            {
                _rozwinięty = value;

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