using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Inne;
using ProgramowanieKlockami.ModelWidoku.Tekst;
using ProgramowanieKlockami.ModelWidoku.Zmienne;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        public ObservableCollection<KlocekPionowy> KlockiPionowe { get; private set; }
        public ObservableCollection<KlocekZwracającyWartość> KlockiZwracająceWartość { get; private set; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; private set; }
        public ObservableCollection<Zmienna> Zmienne { get; private set; }
        public Komenda KomendaDodaniaZmiennej { get; private set; }
        public Komenda KomendaUsunięciaZmiennej { get; private set; }

        private string _nazwaNowejZmiennej;

        public string NazwaNowejZmiennej
        {
            get { return _nazwaNowejZmiennej; }

            set
            {
                _nazwaNowejZmiennej = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Główny()
        {
            KlockiPionowe = new ObservableCollection<KlocekPionowy>
            {
                new Wyświetl(),
                new UstawZmienną()
            };

            KlockiZwracająceWartość = new ObservableCollection<KlocekZwracającyWartość>
            {
                new Napis(),
                new WartośćZmiennej()
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);

            throw new Exception("ogar stylów");
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) {Nazwa = NazwaNowejZmiennej});

                NazwaNowejZmiennej = null;
            }
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = zmiennaDoUsunięcia as Zmienna;

            if (zmienna != null)
                Zmienne.Remove(zmienna);
        }
    }
}