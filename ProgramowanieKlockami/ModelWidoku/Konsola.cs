using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Konsola : INotifyPropertyChanged
    {
        private string _zawartość;

        public string Zawartość
        {
            get { return _zawartość; }

            private set
            {
                _zawartość = value;

                OnPropertyChanged();
            }
        }

        public Konsola()
        {
            Zawartość = string.Empty;
        }

        public void Czyść()
        {
            Zawartość = string.Empty;
        }

        public void DodajLinię(string linia)
        {
            Zawartość += linia + Environment.NewLine;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}