using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class Klocek : INotifyPropertyChanged
    {
        public abstract string Nazwa { get; }
        public abstract string Opis { get; }
        public abstract Brush Kolor { get; }

        private bool _posiadaSkupienie;

        public bool PosiadaSkupienie
        {
            get { return _posiadaSkupienie; }

            set
            {
                _posiadaSkupienie = value;
                KolorObramowania = PosiadaSkupienie ? Kolory.Skupienie : Kolor;

                OnPropertyChanged();
            }
        }

        private Brush _kolorObramowania;

        public Brush KolorObramowania
        {
            get { return _kolorObramowania; }

            set
            {
                _kolorObramowania = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}