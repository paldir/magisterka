using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        public ObservableCollection<KlocekPionowy> KlockiPionowe { get; }
        public ObservableCollection<KlocekZwracającyWartość> KlockiZwracająceWartość { get; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public ObservableCollection<OpcjaPowiększenia> OpcjePowiększenia { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Klocek Test { get; }

        private string _nazwaNowejZmiennej;
        private OpcjaPowiększenia _wybranePowiększenie;

        public string NazwaNowejZmiennej
        {
            get { return _nazwaNowejZmiennej; }

            set
            {
                _nazwaNowejZmiennej = value;

                OnPropertyChanged();
            }
        }

        public OpcjaPowiększenia WybranePowiększenie
        {
            get { return _wybranePowiększenie; }

            set
            {
                _wybranePowiększenie = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Główny()
        {
            KlockiPionowe = new ObservableCollection<KlocekPionowy>
            {
                new Jeżeli(),
                new Wyświetl(),
                new UstawZmienną()
            };

            KlockiZwracająceWartość = new ObservableCollection<KlocekZwracającyWartość>
            {
                new Porównanie(),
                new Napis(),
                new WartośćZmiennej()
            };

            OpcjePowiększenia = new ObservableCollection<OpcjaPowiększenia>
            {
                new OpcjaPowiększenia(2),
                new OpcjaPowiększenia(1)
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu() {Następny = new Jeżeli() {Wartość = new Porównanie()}};
            Zmienne = new ObservableCollection<Zmienna>();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            Test = new Porównanie();
            WybranePowiększenie = OpcjePowiększenia.Single(o => Math.Abs(o.Powiększenie - 1) < 0.0001);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) { Nazwa = NazwaNowejZmiennej });

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