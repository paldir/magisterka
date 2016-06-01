using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class Klocek : ICloneable, INotifyPropertyChanged
    {
        public abstract Brush Kolor { get; }
        public abstract string Nazwa { get; }
        public abstract string Opis { get; }

        public bool ZPrzybornika { get; set; }

        private bool _aktywny;

        public bool Aktywny
        {
            get { return _aktywny; }

            set
            {
                _aktywny = value;

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

        public virtual object Clone()
        {
            return Activator.CreateInstance(GetType());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}