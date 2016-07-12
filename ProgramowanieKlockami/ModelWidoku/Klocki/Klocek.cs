using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class Klocek : ICloneable, INotifyPropertyChanged
    {
        private bool _aktywny;
        private Brush _kolorObramowania;
        private bool _posiadaSkupienie;

        public abstract string Nazwa { get; }
        public abstract string Opis { get; }

        public Brush Kolor { get; protected set; }
        public bool ZPrzybornika { get; set; }

        public bool Aktywny
        {
            get { return _aktywny; }

            set
            {
                _aktywny = value;

                OnPropertyChanged();
            }
        }

        public Brush KolorObramowania
        {
            get { return _kolorObramowania; }

            set
            {
                _kolorObramowania = value;

                OnPropertyChanged();
            }
        }

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

        protected Klocek()
        {
            PosiadaSkupienie = false;
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