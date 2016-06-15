using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Pętle;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        private Klocek _klocekPosiadającySkupienie;

        public IEnumerable<IDziałanieLogiczne> DziałaniaLogiczne { get; }
        public IEnumerable<IDziałanieMatematyczne> DziałaniaMatematyczne { get; }
        public IEnumerable<Klocek> KlockiDotyczącePętli { get; }
        public IEnumerable<Klocek> KlockiDotycząceZmiennych { get; }
        public IEnumerable<Klocek> KlockiLogiczne { get; }
        public IEnumerable<Klocek> KlockiMatematyczne { get; }
        public IEnumerable<Klocek> KlockiTekstowe { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaPrzejęciaSkupienia { get; }
        public Komenda KomendaStartuProgramu { get; }
        public Komenda KomendaUsunięciaKlockaPionowego { get; }
        public Komenda KomendaUsunięciaKlockaZwracającegoWartość { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Komenda KomendaZwinięciaRozwinięciaKlockaZZawartością { get; }
        public Konsola Konsola { get; }
        public ObsługującyPrzeciąganieZPrzybornika ObsługującyPrzeciąganieZPrzybornika { get; }
        public ObsługującyPrzenoszenieKlockówPionowych ObsługującyPrzenoszenieKlockówPionowych { get; }
        public ObsługującyPrzenoszenieKlockówZwracającychWartość ObsługującyPrzenoszenieKlockówZwracającychWartość { get; }
        public ObsługującyUpuszczanieKlockówPionowych ObsługującyUpuszczanieKlockówPionowych { get; }
        public ObsługującyUpuszczanieKlockówZwracającychWartość ObsługującyUpuszczanieKlockówZwracającychWartość { get; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public IEnumerable<IStałaLogiczna> StałeLogiczne { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public IEnumerable<IZnakPorównania> ZnakiPorównania { get; }

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

        public Główny()
        {
            Konsola = new Konsola();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaPrzejęciaSkupienia = new Komenda(PrzejmijSkupienie);
            KomendaStartuProgramu = new Komenda(RozpocznijWykonywanieProgramu);
            KomendaUsunięciaKlockaPionowego = new Komenda(UsuńKlocekPionowy) { MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy };
            KomendaUsunięciaKlockaZwracającegoWartość = new Komenda(UsuńKlocekZwracającyWartość);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            KomendaZwinięciaRozwinięciaKlockaZZawartością = new Komenda(ZwińRozwińKlocekZZawartością) { MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy };
            ObsługującyPrzeciąganieZPrzybornika = new ObsługującyPrzeciąganieZPrzybornika();
            ObsługującyPrzenoszenieKlockówPionowych = new ObsługującyPrzenoszenieKlockówPionowych();
            ObsługującyPrzenoszenieKlockówZwracającychWartość = new ObsługującyPrzenoszenieKlockówZwracającychWartość();
            ObsługującyUpuszczanieKlockówPionowych = new ObsługującyUpuszczanieKlockówPionowych();
            ObsługującyUpuszczanieKlockówZwracającychWartość = new ObsługującyUpuszczanieKlockówZwracającychWartość();
            Powiększenie = 1;
            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();

            DziałaniaLogiczne = new IDziałanieLogiczne[]
            {
                new Koniunkcja(),
                new Alternatywa()
            };

            DziałaniaMatematyczne = new IDziałanieMatematyczne[]
            {
                new Dodawanie(),
                new Odejmowanie(),
                new Mnożenie(),
                new Dzielenie(),
                new Potęgowanie()
            };

            StałeLogiczne = new IStałaLogiczna[]
            {
                new Prawda(),
                new Fałsz()
            };

            ZnakiPorównania = new IZnakPorównania[]
            {
                new Równy(),
                new Nierówny(),
                new Mniejszy(),
                new MniejszyRówny(),
                new Większy(),
                new WiększyRówny()
            };

            KlockiDotyczącePętli = new Klocek[]
            {
                new Dopóki(),
                new Odliczanie(),
                new Przerwij()
            };

            KlockiDotycząceZmiennych = new Klocek[]
            {
                new UstawZmienną(),
                new WartośćZmiennej()
            };

            KlockiLogiczne = new Klocek[]
            {
                new Jeżeli(),
                new Negacja(),
                new Porównanie {WybranyZnakPorównania = ZnakiPorównania.First()},
                new StałaLogiczna {WybranaStałaLogiczna = StałeLogiczne.First()},
                new WarunekZłożony {WybraneDziałanie = DziałaniaLogiczne.First()}
            };

            KlockiMatematyczne = new Klocek[]
            {
                new Stała(),
                new WynikDziałania {WybraneDziałanieMatematyczne = DziałaniaMatematyczne.First()}
            };

            KlockiTekstowe = new Klocek[]
            {
                new Napis(),
                new Wyświetl {Konsola = Konsola}
            };
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

        private void RozpocznijWykonywanieProgramu()
        {
            Konsola.Czyść();
            RozpoczęcieProgramu.Wykonaj();
        }

        private bool SprawdźCzyMożnaUsunąćKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = _klocekPosiadającySkupienie as KlocekPionowy;

            return usuwanyKlocek?.Rodzic != null;
        }

        private bool SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy()
        {
            KlocekPionowyZZawartością klocek = _klocekPosiadającySkupienie as KlocekPionowyZZawartością;

            return klocek != null;
        }

        private void UsuńKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = (KlocekPionowy) _klocekPosiadającySkupienie;
            ZawartośćKlockaPionowegoZZawartością miejsceUmieszczenia = usuwanyKlocek.Rodzic.Zawartość;

            miejsceUmieszczenia?.Remove(usuwanyKlocek);
        }

        private void UsuńKlocekZwracającyWartość()
        {
            KlocekZwracającyWartość usuwanyKlocek = (KlocekZwracającyWartość)_klocekPosiadającySkupienie;
            usuwanyKlocek.MiejsceUmieszczenia[0] = null;
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = (Zmienna)zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }

        private void ZwińRozwińKlocekZZawartością()
        {
            KlocekPionowyZZawartością klocek = (KlocekPionowyZZawartością)_klocekPosiadającySkupienie;
            klocek.Rozwinięty = !klocek.Rozwinięty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}