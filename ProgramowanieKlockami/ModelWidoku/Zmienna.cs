using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Zmienna : INotifyPropertyChanged
    {
        private string _nazwa;
        private object _wartość;
        private readonly ObservableCollection<Zmienna> _zmienne;

        public string Nazwa
        {
            get { return _nazwa; }

            set
            {
                _nazwa = value;

                if (string.IsNullOrEmpty(value))
                    _zmienne.Remove(this);
            }
        }

        public object Wartość
        {
            get { return _wartość; }

            set
            {
                _wartość = value;
                ZmiennaTypuListowego zmiennaTypuListowego = Wartość as ZmiennaTypuListowego;

                if (zmiennaTypuListowego != null)
                    zmiennaTypuListowego.CollectionChanged += ZmiennaTypuListowego_CollectionChanged;

                OnPropertyChanged();
            }
        }

        public Zmienna(ObservableCollection<Zmienna> zmienne)
        {
            _zmienne = zmienne;
        }

        private void ZmiennaTypuListowego_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Wartość");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}