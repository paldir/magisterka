using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class MagazynZmian :INotifyPropertyChanged
    {
        private int _indeksAktualnegoStanu;
        private bool _możnaCofnąć;
        private bool _możnaPrzywrócić;
        private readonly ObservableCollection<ManipulacjaKlockiem> _manipulacje;

        public bool MożnaCofnąć
        {
            get { return _możnaCofnąć; }

            private set
            {
                _możnaCofnąć = value;

                OnPropertyChanged();
            }
        }

        public bool MożnaPrzywrócić
        {
            get { return _możnaPrzywrócić; }

            private set
            {
                _możnaPrzywrócić = value;

                OnPropertyChanged();
            }
        }

        public MagazynZmian()
        {
            _manipulacje = new ObservableCollection<ManipulacjaKlockiem>();
            _indeksAktualnegoStanu = -1;
            MożnaCofnąć = false;
            MożnaPrzywrócić = false;
        }

        public void Cofnij()
        {
            if (_indeksAktualnegoStanu >= 0)
            {
                _manipulacje[_indeksAktualnegoStanu].Cofnij();

                _indeksAktualnegoStanu--;
            }

            if (_indeksAktualnegoStanu == -1)
                MożnaCofnąć = false;

            if (_indeksAktualnegoStanu < _manipulacje.Count)
                MożnaPrzywrócić = true;
        }

        public void DodajDziałanie(ManipulacjaKlockiem manipulacja)
        {
            for (int i = _manipulacje.Count - 1; i > _indeksAktualnegoStanu; i--)
                _manipulacje.RemoveAt(i);

            _manipulacje.Add(manipulacja);

            _indeksAktualnegoStanu++;

            if (_indeksAktualnegoStanu >= 0)
                MożnaCofnąć = true;

            MożnaPrzywrócić = false;
        }

        public void Przywróć()
        {
            int liczbaStanów = _manipulacje.Count;

            if (_indeksAktualnegoStanu < liczbaStanów - 1)
            {
                _indeksAktualnegoStanu++;

                _manipulacje[_indeksAktualnegoStanu].Przywróć();
            }

            if (_indeksAktualnegoStanu == liczbaStanów - 1)
                MożnaPrzywrócić = false;

            if (_indeksAktualnegoStanu >= 0)
                MożnaCofnąć = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}