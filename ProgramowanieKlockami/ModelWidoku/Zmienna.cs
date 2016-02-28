using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Zmienna
    {
        private string _nazwa;
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

        public Zmienna(ObservableCollection<Zmienna> zmienne)
        {
            _zmienne = zmienne;
        }
    }
}