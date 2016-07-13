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

                OnPropertyChanged();
            }
        }

        public Zmienna(ObservableCollection<Zmienna> zmienne)
        {
            _zmienne = zmienne;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}