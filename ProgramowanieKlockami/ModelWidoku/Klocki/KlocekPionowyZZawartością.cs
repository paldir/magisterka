using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : IKlocekPionowyZZawartością
    {
        public abstract string Nazwa { get; }
        public abstract string Opis { get; }
        public abstract Brush Kolor { get; }
        public ObservableCollection<IKlocekPionowy> Zawartość { get; }
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
            Zawartość = new ObservableCollection<IKlocekPionowy>();
            Widoczny = true;
            OdwrócenieWidoczności = new Komenda(OdwróćWidoczność);
        }

        private void OdwróćWidoczność()
        {
            Widoczny = !Widoczny;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}