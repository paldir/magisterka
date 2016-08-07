using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class Klocek : ICloneable, INotifyPropertyChanged
    {
        private bool _aktywny;
        private bool _błąd;
        private ObservableCollection<BłądKlocka> _błędy;
        private Brush _kolor;
        private Brush _kolorObramowania;
        private bool _posiadaSkupienie;

        protected abstract WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące { get; }

        public abstract string Nazwa { get; }
        public abstract string Opis { get; }

        public Brush KolorPierwotny { get; private set; }
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

        public bool Błąd
        {
            get { return _błąd; }

            set
            {
                _błąd = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<BłądKlocka> Błędy
        {
            get { return _błędy; }

            protected set
            {
                _błędy = value;

                OnPropertyChanged();
            }
        }

        public Brush Kolor
        {
            get { return _kolor; }

            protected set
            {
                if (KolorObramowania == null)
                    KolorObramowania = value;

                if (KolorPierwotny == null)
                    KolorPierwotny = value;

                _kolor = value;

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
                //KolorObramowania = PosiadaSkupienie ? Kolory.Skupienie : Kolor;
                KolorObramowania = Kolor;

                OnPropertyChanged();
            }
        }

        protected Klocek()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            PosiadaSkupienie = false;
        }

        protected void SprawdźPoprawnośćKlockówKonfigurujących()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            Błąd = false;

            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćWewnętrznegoKlockaZwracającegoWartość in KlockiKonfigurujące)
            {
                Type oczekiwanyTyp = wartośćWewnętrznegoKlockaZwracającegoWartość.PrzyjmowanyTyp;
                Type umieszczonyTyp = wartośćWewnętrznegoKlockaZwracającegoWartość[0]?.Zwróć<object>(true)?.GetType();

                if (!oczekiwanyTyp.IsAssignableFrom(umieszczonyTyp))
                {
                    Błąd = true;

                    Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(oczekiwanyTyp, umieszczonyTyp)); });
                }
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