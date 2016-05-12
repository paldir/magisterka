using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        private Klocek _klocekPosiadającySkupienie;

        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Komenda KomendaPrzejęciaSkupienia { get; }
        public Komenda KomendaUsunięciaKlockaPionowego { get; }
        public Komenda KomendaUsunięciaKlockaZwracającegoWartość { get; }
        public Komenda KomendaZwinięciaRozwinięciaKlockaZZawartością { get; }
        public IEnumerable<Klocek> KlockiLogiczne { get; }
        public IEnumerable<Klocek> KlockiTekstowe { get; }
        public IEnumerable<Klocek> KlockiDotycząceZmiennych { get; }
        public ObsługującyUpuszczanieKlockówPionowych ObsługującyUpuszczanieKlockówPionowych { get; }
        public ObsługującyUpuszczanieKlockówZwracającychWartość ObsługującyUpuszczanieKlockówZwracającychWartość { get; }

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

        private double _powiększenie;

        public double Powiększenie
        {
            get { return _powiększenie; }

            set
            {
                _powiększenie = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Główny()
        {
            KlockiLogiczne = new Klocek[]
            {
                new Jeżeli(),
                new Porównanie()
            };

            KlockiTekstowe = new Klocek[]
            {
                new Napis(),
                new Wyświetl()
            };

            KlockiDotycząceZmiennych = new Klocek[]
            {
                new UstawZmienną(),
                new WartośćZmiennej()
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            KomendaPrzejęciaSkupienia = new Komenda(PrzejmijSkupienie);
            KomendaUsunięciaKlockaPionowego = new Komenda(UsuńKlocekPionowy) { MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy };
            KomendaUsunięciaKlockaZwracającegoWartość = new Komenda(UsuńKlocekZwracającyWartość);
            KomendaZwinięciaRozwinięciaKlockaZZawartością = new Komenda(ZwińRozwińKlocekZZawartością) { MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy };
            Powiększenie = 1;
            ObsługującyUpuszczanieKlockówPionowych = new ObsługującyUpuszczanieKlockówPionowych();
            ObsługującyUpuszczanieKlockówZwracającychWartość = new ObsługującyUpuszczanieKlockówZwracającychWartość();
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
            Zmienna zmienna = (Zmienna)zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }

        private void PrzejmijSkupienie(object obiektKlocka)
        {
            if (_klocekPosiadającySkupienie != null)
                _klocekPosiadającySkupienie.PosiadaSkupienie = false;

            Klocek klocek = (Klocek)obiektKlocka;
            klocek.PosiadaSkupienie = true;
            _klocekPosiadającySkupienie = klocek;
            KomendaUsunięciaKlockaPionowego.MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy;
            KomendaZwinięciaRozwinięciaKlockaZZawartością.MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy;
        }

        private void UsuńKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = (KlocekPionowy)_klocekPosiadającySkupienie;
            ObservableCollection<KlocekPionowy> miejsceUmieszczenia = usuwanyKlocek.MiejsceUmieszczenia;

            miejsceUmieszczenia?.Remove(usuwanyKlocek);
        }

        private bool SprawdźCzyMożnaUsunąćKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = (KlocekPionowy)_klocekPosiadającySkupienie;

            if (usuwanyKlocek == null)
                return false;

            return usuwanyKlocek.MiejsceUmieszczenia != null;
        }

        private void UsuńKlocekZwracającyWartość()
        {
            KlocekZwracającyWartość usuwanyKlocek = (KlocekZwracającyWartość)_klocekPosiadającySkupienie;
            usuwanyKlocek.MiejsceUmieszczenia[0] = null;
        }

        private void ZwińRozwińKlocekZZawartością()
        {
            KlocekPionowyZZawartością klocek = (KlocekPionowyZZawartością)_klocekPosiadającySkupienie;
            klocek.Rozwinięty = !klocek.Rozwinięty;
        }

        private bool SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy()
        {
            KlocekPionowyZZawartością klocek = _klocekPosiadającySkupienie as KlocekPionowyZZawartością;

            return klocek != null;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}